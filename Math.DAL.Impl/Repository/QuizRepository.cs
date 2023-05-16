using Entities;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;

namespace Math.DAL.Repository;

public class QuizRepository : GenericRepository<int, Quiz>, IQuizRepository
{
    public QuizRepository(MathContext dbContext) : base(dbContext)
    {
    }
}

