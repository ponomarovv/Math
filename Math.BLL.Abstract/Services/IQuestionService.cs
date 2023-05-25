using Models;

namespace Math.BLL.Abstract.Services;

public interface IQuestionService : IService<QuestionModel>
{
    void StartGame();
    
    Task<ICollection<QuestionModel>> Get10RandomQuestions();
    Task<ICollection<QuestionModel>> GetQuestionsByTopic(string topic);
    Task<ICollection<QuestionModel>> Get10RandomArithmeticQuestions();
    Task<ICollection<QuestionModel>> Get10RandomGeometryQuestions();

    Task<QuestionModel> CreateAsync(QuestionModel model);
    Task<List<QuestionModel>> GetAllAsync();
    Task<QuestionModel> GetByIdAsync(int id);
    Task<bool> UpdateAsync(QuestionModel model);
    Task<bool> DeleteAsync(int id);
}
