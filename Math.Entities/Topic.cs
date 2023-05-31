namespace Entities;

public class Topic
{
    public int Id { get; set; }
    
    public string? Text { get; set; }
    
    public virtual ICollection<Question> Questions { get; set; }

    public virtual ICollection<Quiz> Quizzes { get; set; }
    public virtual ICollection<Book> Books { get; set; }
    public Topic AnotherTopic { get; set; }
}
