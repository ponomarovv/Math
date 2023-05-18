using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("Quizzes")]
public class Quiz
{
    public int Id { get; set; }
    public DateTime? QuizDate { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

    public virtual ICollection<Topic> Topics { get; set; }
}
