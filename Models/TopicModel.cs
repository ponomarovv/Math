﻿namespace Models;

public class TopicModel
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public ICollection<QuestionModel> QuestionModels { get; set; }
}