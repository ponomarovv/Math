﻿namespace Math.DAL.Abstract.Repository.Base;

public interface IUnitOfWork : IDisposable
{
    IAnswerRepository AnswerRepository { get; }
    IQuestionRepository QuestionRepository { get; }
    ITopicRepository TopicRepository { get; }
    IChildrenTopicRepository ChildrenTopicRepository { get; }
    IQuizRepository QuizRepository { get; }

    
    
    Task SaveChangesAsync();
}
