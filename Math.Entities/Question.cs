using Entities;

namespace Entities;

public class Question
{
    public int Id { get; set; }
    public string? Text { get; set; }


    public Topic Topic { get; set; } = new Topic();
    public virtual ICollection<Answer> Answers { get; set; }
}
