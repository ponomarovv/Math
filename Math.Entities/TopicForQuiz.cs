namespace Entities;

public class TopicForQuiz
{
    public int Id { get; set; }
    public Quiz Quiz { get; set; }
    public Topic Topic { get; set; }
}
