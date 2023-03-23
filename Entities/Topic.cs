namespace Entities;

public class Topic
{
    public int Id { get; set; }
    public string? Text { get; set; }
    
    public ICollection<Question> Questions { get; set; }
}
