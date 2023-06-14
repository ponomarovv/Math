using Entities.Auth;

namespace Models;

public class QuizModel
{
    public int Id { get; set; }
    public DateTime? QuizDate { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

    public ICollection<TopicForQuizModel> TopicQuizzes { get; set; }

    public int MainTopicId { get; set; }
    public TopicModel.TopicModel MainTopic { get; set; }
}
