using Entities.Auth;

namespace Models;

public class QuizModel
{
    public int Id { get; set; }
    public DateTime? QuizDate { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

    public virtual ICollection<TopicModel.TopicModel> Topics { get; set; }
}

