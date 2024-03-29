﻿namespace Entities.TopicEntity;

public class Topic
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public ICollection<Question> Questions { get; set; }

    public ICollection<Quiz> Quizzes { get; set; }
    public ICollection<Book> Books { get; set; }


    public ICollection<ChildrenTopic> ChildrenTopics { get; set; }
}
