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
        services.AddTransient<IAnswerRepository, AnswerRepository>();
        services.AddTransient<IQuestionRepository, QuestionRepository>();
        services.AddTransient<ITopicRepository, TopicRepository>();
        
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
