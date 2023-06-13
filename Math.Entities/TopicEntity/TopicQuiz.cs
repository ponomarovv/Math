namespace Entities.TopicEntity;

public class TopicQuiz
{
    public int TopicId { get; set; }
    public Topic Topic { get; set; }

    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
}
