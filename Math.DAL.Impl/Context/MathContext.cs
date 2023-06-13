using Entities;
using Entities.Auth;
using Entities.TopicEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Context;

public class MathContext : IdentityDbContext
{
    public MathContext(DbContextOptions<MathContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new TopicConfiguration());
        builder.ApplyConfiguration(new QuizConfiguration());
        builder.ApplyConfiguration(new TopicQuizConfiguration());
    }

    public DbSet<Topic> Topics { get; set; }
    public DbSet<ChildrenTopic> ChildrenTopics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }

}
