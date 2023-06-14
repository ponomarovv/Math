using Entities.Auth;
using Models.TopicModelFolder;

namespace Models;

public class QuizModel
{
    public int Id { get; set; }
    public DateTime? QuizDate { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

    public ICollection<TopicModel> Topics { get; set; }

    public int MainTopicId { get; set; }
    public string MainTopicText  { get; set; }
}
