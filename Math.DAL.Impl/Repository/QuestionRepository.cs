using Entities;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Repository;

public class QuestionRepository : GenericRepository<int, Question>, IQuestionRepository
{
    private readonly MathContext _dbContext;

    public QuestionRepository(MathContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<List<Question>> GetAllAsync(Func<Question, bool> predicate)
    {
        List<Question> items = await _dbContext.Questions.Include(x => x.Answers).Where(predicate).AsQueryable().ToListAsync();
        return items;
    }

    public override async Task<Question> GetByIdAsync(int key)
    {
        var item = await _dbContext.Questions.Where(x => x.Id == key).Include(x => x.Answers).Include(x => x.Topic).FirstOrDefaultAsync();
        return item;
    }
}
