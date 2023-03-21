using Entities;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;

namespace Math.DAL.Repository;

public class QuestionRepository : GenericRepository<int, Question>, IQuestionRepository
{
    public QuestionRepository(MathContext dbContext) : base(dbContext)
    {
    }
}

