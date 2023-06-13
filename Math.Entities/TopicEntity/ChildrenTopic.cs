namespace Entities.TopicEntity;

public class ChildrenTopic
{
    public int Id { get; set; }
    public string? Text { get; set; }

    public ICollection<Topic> Topics { get; set; }
}
