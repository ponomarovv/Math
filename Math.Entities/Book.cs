using System.ComponentModel.DataAnnotations.Schema;
using Entities.TopicEntity;

namespace Entities;

[Table("Books")]
public class Book
{
    public int Id { get; set; }
    public string Text { get; set; }

    public ICollection<Topic> Topics { get; set; }
}
