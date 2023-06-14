namespace Models;

public class TopicForQuizModel
{
    public int Id { get; set; }
    public QuizModel QuizModel { get; set; }
    public TopicModel.TopicModel TopicModel { get; set; }
}
