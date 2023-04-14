using Math.BLL;
using Math.DAL;
using Math.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Math.WEB;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add secrets configuration
        builder.Configuration.AddUserSecrets<Program>();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        // Configure DbContext with the retrieved connection string

        builder.Services.AddDbContext<MathContext>(
            options => options.UseSqlServer(connectionString));

        builder.Services.InstallRepositories();
        builder.Services.InstallMappers();
        builder.Services.InstallServices();



        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

        builder.Services.AddCors();

        builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<MathContext>();

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
