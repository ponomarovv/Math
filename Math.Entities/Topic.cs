namespace Entities;

public class Topic
{
    public int Id { get; set; }
    public int TopicId { get; set; }
    public string? Text { get; set; }
    
    public virtual ICollection<Question> Questions { get; set; }

    public virtual ICollection<Quiz> Quizzes { get; set; }
}
