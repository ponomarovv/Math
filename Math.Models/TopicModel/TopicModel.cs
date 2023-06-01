namespace Models;

public class TopicModel
{
    public int Id { get; set; }
   
    public string? Text { get; set; }
    public virtual ICollection<QuestionModel> QuestionModels { get; set; }
    public virtual ICollection<QuizModel> QuizModels { get; set; }
    public virtual ICollection<BookModel> BookModels { get; set; }
    
    public int? ParentTopicId { get; set; }
    public virtual TopicModel ParentTopic { get; set; }
    public virtual ICollection<TopicModel> ChildTopics { get; set; }
}
