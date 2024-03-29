﻿using Entities.TopicEntity;

namespace Entities;

public class Question
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public Topic Topic { get; set; }
    public  ICollection<Answer> Answers { get; set; }
}
