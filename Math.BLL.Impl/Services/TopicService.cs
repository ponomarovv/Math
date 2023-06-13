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

    private Dictionary<int, TopicNode> _tree = new();


    public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

        _tree = LoadTreeFromJson();


        // _tree = new Dictionary<int, TopicNode>()
        // {
        //     {1, new TopicNode(){Children = {2,3}}},
        //     {2, new TopicNode(){Children = {4,6}, Parents = {1}}},
        //     {3, new TopicNode(){Children = {6}, Parents = {1}}},
        //     {4, new TopicNode(){Children = {5}, Parents = {2}}},
        //     {6, new TopicNode(){Children = {5,7}, Parents = {2,3}}}
        // };

        // CreateTree();
    }

    private void CreateTree()
    {
        InitializeTree();
        SaveTreeToJson();
    }

    private async Task InitializeTree()
    {
        List<TopicModel> parentTopics = await GetAllAsync();
        List<ChildrenTopicModel> childrenTopics = await GetAllChildrenAsync();


        foreach (var parent in parentTopics)
        {
            _tree.Add(parent.Id, new TopicNode());
    
            foreach (var child in parent.ChildrenTopicModels)
            {
                _tree[parent.Id].Children.Add(child.Id);
            }

            _tree[parent.Id].Children.Sort();
        }

        foreach (var child in childrenTopics)
        {
            foreach (var parent in child.Topics)
            {
                _tree[child.Id].Parents.Add(parent.Id);
            }

            _tree[child.Id].Parents.Sort();
        }
    }

    private void SaveTreeToJson()
    {
        string jsonString = JsonSerializer.Serialize(_tree, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("../tree.json", jsonString);
    }

    private Dictionary<int, TopicNode> LoadTreeFromJson()
    {
        string jsonString = File.ReadAllText("../tree.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<Dictionary<int, TopicNode>>(jsonString, options);
    }

    private List<int> GetAllTopicIdsRecursive(int id)
    {
        List<int> result = new List<int>();


        if (_tree.ContainsKey(id) && _tree[id].Children.Count != 0)
        {
            var children = _tree[id].Children;
        
            foreach (var child in children)
            {
                result.Add(child);
                result.AddRange(GetAllTopicIdsRecursive(child));
            }
        }

        return result;
    }

    public async Task<TopicModel> GetTopicByTopicText(string text)
    {
        var allTopics = await GetAllAsync();
        var topic = allTopics.FirstOrDefault(t => t.Text == text);

        return topic;
    }

    public async Task<List<TopicModel>> GetTopicIdsByTopicText(string text)
    {
        var result = new List<TopicModel>();
        var allTopics = await GetAllAsync();
        var topic = allTopics.FirstOrDefault(t => t.Text == text);

        if (topic != null)
        {
            var ids = GetAllTopicIdsRecursive(topic.Id);
            ids.Add(topic.Id);

            result = GetAllAsync().Result.Where(x => ids.Contains(x.Id)).ToList();
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

    public async Task<List<ChildrenTopicModel>> GetAllChildrenAsync()
    {
        var entities = await _unitOfWork.ChildrenTopicRepository.GetAllAsync(x => true);
        var result = entities.Select(_mapper.Map<ChildrenTopicModel>).ToList();

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
