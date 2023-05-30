namespace Entities;

public class Book
{
    public int Id { get; set; }
    public string Text { get; set; }

    public Topic Topic { get; set; }
}
