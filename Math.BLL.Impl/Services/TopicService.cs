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

    private Dictionary<int, List<int>> tree;


    public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

        InitializeTree();
    }

    private void InitializeTree()
    {
        tree = new Dictionary<int, List<int>>();
        tree.Add(3, new List<int> { 2, 4 });
        tree.Add(4, new List<int> { 5 });
        tree.Add(5, new List<int> { 1 });
        tree.Add(2, new List<int>());
        tree.Add(1, new List<int>());

        SaveTreeToJson();
    }

    private void SaveTreeToJson()
    {
        string jsonString = JsonSerializer.Serialize(tree, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("../tree.json", jsonString);
        Console.WriteLine("JSON was saved");
        Console.WriteLine();
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
        var allTopics = await GetAllAsync();
        var topic = allTopics.FirstOrDefault(t => t.Text == text);

        var ids = GetAllTopicIdsRecursive(topic.Id);
        ids.Add(topic.Id);

        var result = GetAllAsync().Result.Where(x => ids.Contains(x.Id)).Select(x => x.Text);

        return result.ToList();
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
