namespace Models.TopicModel;

public class ChildrenTopicModel
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public ICollection<QuestionModel> Questions { get; set; }

    public ICollection<QuizModel> Quizzes { get; set; }
    public ICollection<BookModel> Books { get; set; }



    public ICollection<TopicModel> Topics { get; set; }
}
