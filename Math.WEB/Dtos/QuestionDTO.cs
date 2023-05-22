namespace Math.WEB.Dtos;

public class QuestionDTO
{
    public int Id { get; set; }
    public string? Text { get; set; }


    public TopicDTO Topic { get; set; }
    public virtual ICollection<AnswerDTO> Answers { get; set; }
}
