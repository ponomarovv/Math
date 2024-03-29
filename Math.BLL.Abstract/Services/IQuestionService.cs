﻿using Models;

namespace Math.BLL.Abstract.Services;

public interface IQuestionService : IService<QuestionModel>
{
    Task<ICollection<QuestionModel>> Get10RandomQuestions();
    Task<ICollection<QuestionModel>> GetQuestionsByTopic(string topic);

    Task<QuestionModel> CreateAsync(QuestionModel model);
    Task<List<QuestionModel>> GetAllAsync();
    Task<QuestionModel> GetByIdAsync(int id);
    Task<bool> UpdateAsync(QuestionModel model);
    Task<bool> DeleteAsync(int id);
}
