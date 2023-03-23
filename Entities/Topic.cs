namespace Entities;

public class Topic
{
    public int Id { get; set; }
    public string? Text { get; set; }
    
    public Question[] Questions { get; set; }
}
