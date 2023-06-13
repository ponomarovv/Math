using Entities;
using Entities.TopicEntity;
using Models;
using Models.TopicModel;

namespace Math.BLL.Mappers;

public class MappersProfile : AutoMapper.Profile
{
    public MappersProfile()
    {
        CreateMap<Answer, AnswerModel>()
            .ForMember(dest => dest.QuestionModel, opt => opt.MapFrom(src => src.Question))
            .PreserveReferences()
            .ReverseMap();

        CreateMap<Question, QuestionModel>()
            .ForMember(dest => dest.AnswerModels, opt => opt.MapFrom(src => src.Answers))
            .ForMember(dest => dest.TopicModel, opt => opt.MapFrom(src => src.Topic))
            .PreserveReferences()
            .ReverseMap();

        CreateMap<Topic, TopicModel>()
            .ForMember(dest => dest.QuestionModels, opt => opt.MapFrom(src => src.Questions))
            .ForMember(dest => dest.BookModels, opt => opt.MapFrom(src => src.Books))
            .ForMember(dest => dest.ChildrenTopicModels, opt => opt.MapFrom(src => src.ChildrenTopics))
            .PreserveReferences()
            .ReverseMap();

        CreateMap<ChildrenTopic, ChildrenTopicModel>()
            .PreserveReferences()
            .ReverseMap();

        CreateMap<Quiz, QuizModel>()
            .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics))
            .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
            .PreserveReferences()
            .ReverseMap();
        
        
        CreateMap<Book, BookModel>()
            .PreserveReferences()
            .ReverseMap();
        
                
        CreateMap<TopicForQuiz, TopicForQuizModel>()
            .PreserveReferences()
            .ReverseMap();
    }
}
