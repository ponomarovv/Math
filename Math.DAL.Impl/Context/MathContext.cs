using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Math.DAL.Context;

public class MathContext : DbContext
{
    private readonly IConfiguration _config;

    public MathContext(IConfiguration config)
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
        // Retrieve the connection string secret from IConfiguration
        string? connectionString = _config.GetConnectionString("DefaultConnection");

        // Use the retrieved connection string for configuring DbContext
        optionsBuilder.UseSqlServer(connectionString);
    }


    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    
    public DbSet<ApplicationUser> AppUsers { get; set; }
}
