using System.ComponentModel.DataAnnotations.Schema;

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
    // public Topic? Topic { get; set; }
}
