namespace Math.WEB.Dtos;

public class TopicDTO
{
    public int Id { get; set; }
    public string? Text { get; set; }
    
    public virtual ICollection<QuestionDTO> Questions { get; set; }

    public virtual ICollection<QuizDTO> Quizzes { get; set; }
}
