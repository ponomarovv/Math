﻿namespace Entities;

public class Answer
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public bool IsCorrect { get; set; }

    public Question Question { get; set; } = new Question();
}
