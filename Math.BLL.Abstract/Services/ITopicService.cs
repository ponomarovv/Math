using Models.TopicModel;

namespace Math.BLL.Abstract.Services;

public interface ITopicService : IService<TopicModel>
{
      Task<List<string>> GetTopicIdByTopicText(string text);
}
