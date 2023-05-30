namespace Models;

public class TopicModel
{
    public int Id { get; set; }
    public int TopicId { get; set; }
    public string? Text { get; set; }
    public virtual ICollection<QuestionModel> QuestionModels { get; set; }
    public virtual ICollection<BookModel> BookModels { get; set; }
}
