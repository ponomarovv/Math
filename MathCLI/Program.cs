// See https://aka.ms/new-console-template for more information

using Math.BLL;
using Math.BLL.Abstract.Services;
using Math.BLL.Services;
using Math.DAL;
using Math.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace MathCLI;

public class Program
{
    public static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MathContext>();

        var options = optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;")
            .Options;


        var serviceCollection = new ServiceCollection();

        serviceCollection.InstallRepositories();
        serviceCollection.InstallMappers();
        serviceCollection.InstallServices();


        serviceCollection.AddDbContext<MathContext>
        (options => options.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;Database=MathDB;Trusted_Connection=True;"),
            ServiceLifetime.Singleton
        );

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


        // var dishService = serviceProvider.GetService<IDishService>();
        ITopicService? topicService = serviceProvider.GetService<ITopicService>();

        
        IQuestionService questionService = serviceProvider.GetService<IQuestionService>();
        questionService?.StartGame();
        


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
