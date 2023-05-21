using Models;

namespace Math.BLL.Abstract.Services;

public interface IQuestionService : IService<QuestionModel>
{
    void StartGame();
    
    Task<Dictionary<int, QuestionModel>> Get20RandomQuestions();

    Task<QuestionModel> CreateAsync(QuestionModel model);
    Task<List<QuestionModel>> GetAllAsync();
    Task<QuestionModel> GetByIdAsync(int id);
    Task<bool> UpdateAsync(QuestionModel model);
    Task<bool> DeleteAsync(int id);
}
