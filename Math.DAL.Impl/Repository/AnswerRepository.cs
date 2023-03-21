using Entities;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;

namespace Math.DAL.Repository;

public class AnswerRepository : GenericRepository<int, Answer>, IAnswerRepository
{
    public AnswerRepository(MathContext dbContext) : base(dbContext)
    {
    }
}
