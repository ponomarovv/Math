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

    // public List<Question> GetAll(Func<Question, bool> predicate)
    // {
    //     List<Question> items = _dbContext.Questions.Include(x => x.Answers).Where(predicate).ToList();
    //     return items;
    // }
}
