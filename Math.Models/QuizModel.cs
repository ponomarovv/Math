using Entities;

namespace Models;

public class QuizModel
{
    public int Id { get; set; }
    public DateTime? QuizDate { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

    public virtual ICollection<TopicModel> Topics { get; set; }
}

