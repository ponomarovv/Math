using Models.TopicModel;

namespace Math.BLL.Abstract.Services;

public interface ITopicService : IService<TopicModel>
{
    Task<TopicModel> GetTopicModelByTopicText(string text);
    Task<List<TopicModel>> GetTopicIdsByTopicText(string text);
}
