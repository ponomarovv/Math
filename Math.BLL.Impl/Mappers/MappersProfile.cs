using Entities;
using Models;

namespace Math.BLL.Mappers;

public class MappersProfile : AutoMapper.Profile
{
    public MappersProfile()
    {
        CreateMap<Answer, AnswerModel>()
            .ForMember(dest => dest.QuestionModel, opt => opt.MapFrom(src => src.Question))
            .ReverseMap();

        CreateMap<Question, QuestionModel>()
            .ForMember(dest => dest.AnswerModels, opt => opt.MapFrom(src => src.Answers))
            .ForMember(dest => dest.TopicModel, opt => opt.MapFrom(src => src.Topic))
            .ReverseMap();

        CreateMap<Topic, TopicModel>()
            .ForMember(dest => dest.QuestionModels, opt => opt.MapFrom(src => src.Questions))
            .ReverseMap();
    }
}
