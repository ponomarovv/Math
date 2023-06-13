using Entities.TopicEntity;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Repository;

public class ChildrenTopicRepository: GenericRepository<int, ChildrenTopic>, IChildrenTopicRepository
{
    private readonly MathContext _dbContext;
    public ChildrenTopicRepository(MathContext dbContext) : base(dbContext)
    {
    }
    
    // public override async Task<List<ChildrenTopic>> GetAllAsync(Func<ChildrenTopic, bool> predicate)
    // {
    //     List<ChildrenTopic> items = _dbContext.ChildrenTopics.Include(x => x.Topics)
    //         .Where(predicate).ToList();
    //     return items;
    // }
}
