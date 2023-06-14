namespace Models.TopicModelFolder;

public class TopicNode
{
    public List<int> Parents { get; set; } = new();
    public List<int> Children { get; set; } = new();
}
