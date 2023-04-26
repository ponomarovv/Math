using Math.DAL.Abstract.Repository;
using Math.DAL.Abstract.Repository.Base;
using Math.DAL.Repository;
using Math.DAL.Repository.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Math.DAL;

public static class DalDependencyInstaller
{
    public static void InstallRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
