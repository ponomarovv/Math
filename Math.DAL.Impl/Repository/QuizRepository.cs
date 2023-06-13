using Entities;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Repository;

public class QuizRepository : GenericRepository<int, Quiz>, IQuizRepository
{
    private readonly MathContext _dbContext;
    public QuizRepository(MathContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public override async Task<List<Quiz>> GetAllAsync(Func<Quiz, bool> predicate)
    {
        List<Quiz> items = _dbContext.Quizzes
            .Include(x => x.TopicQuizzes)
            .Where(predicate).ToList();
          
        return items;
    }

    public override async Task<Quiz> GetByIdAsync(int key)
    {
        var item = await _dbContext.Quizzes.Where(x => x.Id == key).Include(x => x.TopicQuizzes)
            .FirstOrDefaultAsync();
        return item;
    }
}

