namespace Models.TopicModel;

public class ChildrenTopicModel
{
    public int Id { get; set; }
    public string? Text { get; set; }

    public ICollection<TopicModel> Topics { get; set; }
}
