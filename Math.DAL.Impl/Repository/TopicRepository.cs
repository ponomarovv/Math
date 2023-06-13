using Entities.TopicEntity;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Repository;

public class TopicRepository : GenericRepository<int, Topic>, ITopicRepository
{
    private readonly MathContext _dbContext;
    public TopicRepository(MathContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public override async Task<List<Topic>> GetAllAsync(Func<Topic, bool> predicate)
    {
        List<Topic> items = _dbContext.Topics.Include(x => x.ChildrenTopics)
            .Where(predicate).ToList();
        return items;
    }
}
