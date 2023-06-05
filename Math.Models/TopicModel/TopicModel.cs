namespace Models.TopicModel;

public class TopicModel
{
    public int Id { get; set; }

    public string? Text { get; set; }
    public ICollection<QuestionModel> QuestionModels { get; set; }
    public ICollection<QuizModel> QuizModels { get; set; }
    public ICollection<BookModel> BookModels { get; set; }

    public int? ParentTopicId { get; set; }
    public TopicModel ParentTopic { get; set; }
    public ICollection<TopicModel> ChildTopics { get; set; }
}
