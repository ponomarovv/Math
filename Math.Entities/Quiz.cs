using System.ComponentModel.DataAnnotations.Schema;
using Entities.Auth;
using Entities.TopicEntity;

namespace Entities;

[Table("Quizzes")]
public class Quiz
{
    public int Id { get; set; }
    public DateTime? QuizDate { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

    // M:N
    public ICollection<TopicQuiz> TopicQuizzes { get; set; }
    
    public int MainTopicId { get; set; }
    public Topic MainTopic { get; set; }
}
