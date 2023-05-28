using AutoMapper;
using Math.BLL.Abstract.Services;
using Math.BLL.Mappers;
using Math.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Math.BLL;

public static class BllDependencyInstaller
{
    public static void InstallServices(this IServiceCollection services)
    {
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<ITopicService, TopicService>();
    }

    public static void InstallMappers(this IServiceCollection services)
    {
        var config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappersProfile());
        });

        IMapper mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }
}
