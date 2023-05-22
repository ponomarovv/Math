using Entities;
using Models;

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
            .PreserveReferences()
            .ReverseMap();

        CreateMap<Quiz, QuizModel>()
            .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics))
            .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
            .PreserveReferences()
            .ReverseMap();
    }
}
