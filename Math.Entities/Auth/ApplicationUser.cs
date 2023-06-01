using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Entities.Auth;

public class ApplicationUser : IdentityUser
{
    [Column(TypeName ="nvarchar(150)")]
    public string FullName { get; set; }
    // public virtual ICollection<Question> Questions { get; set; }
}
