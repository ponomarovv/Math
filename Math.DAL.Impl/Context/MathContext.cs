using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Context;

public class MathContext : IdentityDbContext
{
    public MathContext(DbContextOptions<MathContext> options) : base(options)
    {
       
    }
    
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<TopicForQuiz> TopicsForQuizzes { get; set; }
}
