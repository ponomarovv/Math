using Entities;
using Models;

namespace Math.BLL.Mappers;

public class MappersProfile : AutoMapper.Profile
{
    public MappersProfile()
    {
        CreateMap<Answer, AnswerModel>().ReverseMap()
            .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.QuestionModel))
            ;
            
        CreateMap<Question, QuestionModel>().ReverseMap()
            .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.AnswerModels))
            .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.TopicModel))
            ;
        
        CreateMap<Topic, TopicModel>().ReverseMap()
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.QuestionModels))
            ;
        

    }
}
