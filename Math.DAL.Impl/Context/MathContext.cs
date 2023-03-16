using Math.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Context;

public class MathContext : DbContext
{
    public MathContext(DbContextOptions<MathContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MathDB;Trusted_Connection=True;");

    
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
}
