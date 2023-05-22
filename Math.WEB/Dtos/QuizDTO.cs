namespace Math.WEB.Dtos;

public class QuizDTO
{
    public int Id { get; set; }
    public DateTime? QuizDate { get; set; }

    public ApplicationUserDTO? ApplicationUser { get; set; }

    public virtual ICollection<TopicDTO> Topics { get; set; }
}
