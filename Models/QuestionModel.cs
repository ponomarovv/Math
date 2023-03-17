namespace Models;

public class QuestionModel
{
    public int Id { get; set; }
    public string? Text { get; set; }
    
    
    public TopicModel? TopicModelic { get; set; }
}
