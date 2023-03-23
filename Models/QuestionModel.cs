namespace Models;

public class QuestionModel
{
    public int Id { get; set; }
    public string? Text { get; set; }
    
    
    public TopicModel? TopicModel { get; set; }
    public AnswerModel[] AnswerModels { get; set; }
}
