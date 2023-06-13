using Entities.TopicEntity;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;

namespace Math.DAL.Repository;

public class ChildrenTopicRepository: GenericRepository<int, ChildrenTopic>, IChildrenTopicRepository
{
    public ChildrenTopicRepository(MathContext dbContext) : base(dbContext)
    {
    }
}
