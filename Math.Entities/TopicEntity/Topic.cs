namespace Entities.TopicEntity;

public class Topic
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<Question> Questions { get; set; }

    public virtual ICollection<Quiz> Quizzes { get; set; }
    public virtual ICollection<Book> Books { get; set; }

   
    public int? ParentTopicId { get; set; }
    public virtual Topic ParentTopic { get; set; }
    public virtual ICollection<Topic> ChildTopics { get; set; }

}
