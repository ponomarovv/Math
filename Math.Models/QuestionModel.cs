namespace Models;

public class QuestionModel
{
    public int Id { get; set; }
    public string? Text { get; set; }
    
    
    public TopicModel.TopicModel? TopicModel { get; set; }
    
    public virtual ICollection<AnswerModel> AnswerModels { get; set; }
}
