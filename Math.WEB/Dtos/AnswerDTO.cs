namespace Math.WEB.Dtos;

public class AnswerDTO
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public bool IsCorrect { get; set; }

    public QuestionDTO Question { get; set; }
}
