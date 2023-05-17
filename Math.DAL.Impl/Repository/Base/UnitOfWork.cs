using Math.DAL.Abstract.Repository;
using Math.DAL.Abstract.Repository.Base;
using Math.DAL.Context;

namespace Math.DAL.Repository.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly MathContext _context;

    public IAnswerRepository AnswerRepository { get; }
    public IQuestionRepository QuestionRepository { get; }
    public ITopicRepository TopicRepository { get; }

    public IQuizRepository QuizRepository { get; }

    public UnitOfWork(MathContext context, 
        IAnswerRepository answerRepository, IQuestionRepository questionRepository, ITopicRepository topicRepository, IQuizRepository quizRepository)
    {
        _context = context;

        AnswerRepository = answerRepository;
        QuestionRepository = questionRepository;
        TopicRepository = topicRepository;
        QuizRepository = quizRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            this._disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
