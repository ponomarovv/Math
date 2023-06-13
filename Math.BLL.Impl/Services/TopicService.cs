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

        Console.WriteLine();

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
        // InitializeTree();
        SaveTreeToJson();
    }

    private async Task InitializeTree()
    {
        // Dictionary<int, TopicNode> tree = new();

        // TopicNode node = new();

        List<TopicModel> parentTopics = await GetAllAsync();
        List<ChildrenTopicModel> childrenTopics = await GetAllChildrenAsync();

        _tree.Add(11,new TopicNode());
        
        foreach (var parent in parentTopics)
        {
            foreach (var child in parent.ChildrenTopicModels)
            {
                Console.WriteLine("hi");

                var a = 2 + 2;
                Console.WriteLine(a);
                
                _tree.Add(parent.Id, new TopicNode());
                if (!_tree.ContainsKey(parent.Id)) _tree.Add(parent.Id, new TopicNode());
                if (!_tree[parent.Id].Children.Contains(child.Id)) _tree[parent.Id].Children.Add(child.Id);
            }

            _tree[parent.Id].Children.Sort();
        }

        foreach (var child in childrenTopics)
        {
            foreach (var parent in child.Topics)
            {
                Console.WriteLine("hi");
                if (!_tree.ContainsKey(child.Id)) _tree.Add(child.Id, new TopicNode());
                if (!_tree[child.Id].Parents.Contains(parent.Id)) _tree[child.Id].Parents.Add(parent.Id);
            }

            _tree[child.Id].Parents.Sort();
        }

        Console.WriteLine("hi");
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

        return JsonSerializer.Deserialize<Dictionary<int,TopicNode>>(jsonString, options);
    }

    List<int> GetAllTopicIdsRecursive(int id)
    {
        List<int> result = new List<int>();


        // if (tree.ContainsKey(id) && tree[id].Count != 0)
        // {
        //     var children = tree[id];
        //
        //     foreach (var child in children)
        //     {
        //         result.Add(child);
        //         result.AddRange(GetAllTopicIdsRecursive(child));
        //     }
        // }

        return result;
    }

    public async Task<TopicModel> GetTopicByTopicText(string text)
    {
        var allTopics = await GetAllAsync();
        var topic = allTopics.FirstOrDefault(t => t.Text == text);

        return topic;
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
