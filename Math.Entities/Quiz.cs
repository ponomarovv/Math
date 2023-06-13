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
    public  ICollection<Topic> Topics { get; set; }
    
    // Main Topic
    public TopicForQuiz? MainTopic { get; set; }
}
