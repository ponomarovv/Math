using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Math.DAL.Context;

public class MathContext : IdentityDbContext
{
    private readonly IConfiguration _config;

    public MathContext()
    {
        
    }
    
    public MathContext(IConfiguration config, DbContextOptions options) : base(options)
    {
        _config = config;
    }
    
    // public MathContext(DbContextOptions<MathContext> options) : base(options)
    // {
    //     //Database.EnsureCreated();
    // }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       string? connectionString = _config.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
    }


    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
}
