using System.Text.Json;
using AutoMapper;
using Entities.TopicEntity;
using Math.BLL.Abstract.Services;
using Math.DAL.Abstract.Repository.Base;
using Models.TopicModel;

namespace Math.BLL.Services;

public class TopicService : ITopicService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private Dictionary<int, TopicNode> tree = new();


    public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

        // tree = LoadTreeFromJson();

        CreateTree();
    }

    private void CreateTree()
    {
        InitializeTree();
        SaveTreeToJson();
    }

    private async Task InitializeTree()
    {
        List<TopicModel> topics = await GetAllAsync();
        
        foreach (var topic in topics)
        {
            var childrenIds = new List<int>();
            foreach (var child in topic.ChildrenTopicModels)
            {
                childrenIds.Add(child.Id);
            }

            tree.Add(topic.Id, childrenIds);
        }
    }

    private void SaveTreeToJson()
    {
        string jsonString = JsonSerializer.Serialize(tree, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("../tree.json", jsonString);
    }

    private Dictionary<int, List<int>> LoadTreeFromJson()
    {
        string jsonString = File.ReadAllText("../tree.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<Dictionary<int, List<int>>>(jsonString, options);
    }

    List<int> GetAllTopicIdsRecursive(int id)
    {
        List<int> result = new List<int>();


        if (tree.ContainsKey(id) && tree[id].Count != 0)
        {
            var children = tree[id];

            foreach (var child in children)
            {
                result.Add(child);
                result.AddRange(GetAllTopicIdsRecursive(child));
            }
        }

        return result;
    }


    public async Task<List<string>> GetTopicIdByTopicText(string text)
    {
        var result = new List<string>();
        var allTopics = await GetAllAsync();
        var topic = allTopics.FirstOrDefault(t => t.Text == text);

        if (topic != null)
        {
            var ids = GetAllTopicIdsRecursive(topic.Id);
            ids.Add(topic.Id);

            result = GetAllAsync().Result.Where(x => ids.Contains(x.Id)).Select(x => x.Text).ToList();
        }

        return result;
    }


    public async Task<TopicModel> CreateAsync(TopicModel model)
    {
        Topic entity = _mapper.Map<Topic>(model);
        Topic newEntity = await _unitOfWork.TopicRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<TopicModel>(newEntity);
    }

    public async Task<List<TopicModel>> GetAllAsync()
    {
        var entities = await _unitOfWork.TopicRepository.GetAllAsync(x => true);
        var result = entities.Select(_mapper.Map<TopicModel>).ToList();

        return result;
    }

    public async Task<TopicModel> GetByIdAsync(int id)
    {
        var result = _mapper.Map<TopicModel>(await _unitOfWork.TopicRepository.GetByIdAsync(id));

        return result;
    }

    public async Task<bool> UpdateAsync(TopicModel model)
    {
        if (model == null)
        {
            return false;
        }

        var entity = _mapper.Map<Topic>(model);

        var result = await _unitOfWork.TopicRepository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _unitOfWork.TopicRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }
}
