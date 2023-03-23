namespace Models;

public class QuestionModel
{
    public int Id { get; set; }
    public string? Text { get; set; }
    
    
    public TopicModel? TopicModel { get; set; }
    
    public ICollection<AnswerModel> AnswerModels { get; set; }
}
