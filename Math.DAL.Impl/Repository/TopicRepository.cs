using Entities;
using Entities.TopicEntity;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;

namespace Math.DAL.Repository;

public class TopicRepository : GenericRepository<int, Topic>, ITopicRepository
{
    public TopicRepository(MathContext dbContext) : base(dbContext)
    {
    }
}
