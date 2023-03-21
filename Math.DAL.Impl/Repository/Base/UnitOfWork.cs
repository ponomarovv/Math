using Math.DAL.Abstract.Repository;
using Math.DAL.Abstract.Repository.Base;
using Math.DAL.Context;

namespace Math.DAL.Repository.Base;

public class UnitOfWork : IUnitOfWork
{
    private MathContext _context;

    public IAnswerRepository AnswerRepository { get; }
    public IQuestionRepository QuestionRepository { get; }
    public ITopicRepository TopicRepository { get; }


    public UnitOfWork(MathContext context)
    {
        _context = context;

        AnswerRepository = new AnswerRepository(_context);
        QuestionRepository = new QuestionRepository(_context);
        TopicRepository = new TopicRepository(_context);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;

    public void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            this.disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
