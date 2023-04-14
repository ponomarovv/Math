// See https://aka.ms/new-console-template for more information

using Math.BLL;
using Math.BLL.Abstract.Services;
using Math.BLL.Services;
using Math.DAL;
using Math.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace MathCLI;

public class Program
{
    public static void Main(string[] args)
    {
        // Create the service collection
        var services = new ServiceCollection();

        // Build the configuration
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<Program>() // Add user secrets
            .Build();

        // Configure DbContext and add to the service collection
        services.AddDbContext<MathContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register other services as needed
        services.InstallRepositories();
        services.InstallServices();
        services.InstallMappers();

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        // Resolve the DbContext and use it as needed
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MathContext>();
            var questionService = scope.ServiceProvider.GetRequiredService<IQuestionService>();
            questionService?.StartGame();

            // Use the dbContext as needed
            // ...
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
       


        // var optionsBuilder = new DbContextOptionsBuilder<MathContext>();
        //
        // var options = optionsBuilder
        //     .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;")
        //     .Options;




  



        // var dishService = serviceProvider.GetService<IDishService>();



        //questions
        // IQuestionService questionService;
        //
        // questionService.Create(new QuestionModel() { });

        // answers
        // IAnswerService answerService;
        //
        // answerService.Create(new AnswerModel(){})

        Console.WriteLine("the end");
    }
}
