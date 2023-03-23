using Entities;
using Models;

namespace Math.BLL.Mappers;

public class MappersProfile : AutoMapper.Profile
{
    public MappersProfile()
    {
        CreateMap<Answer, AnswerModel>()
            .ForMember(dest => dest.QuestionModel, 
                opt => opt.MapFrom(src => src.Question))
            // .IncludeMembers(a=>a.Question)
            // .IncludeMembers(src=> src.Question.Answers).ReverseMap()
            ;
            
        // CreateMap<Question, QuestionModel>().ReverseMap()
        //     .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.AnswerModels))
        //     .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.TopicModel))
        //     ;    
        
        CreateMap<Question, QuestionModel>()
            .ForMember(dest => dest.AnswerModels, opt => opt.MapFrom(src => src.Answers))
            .ForMember(dest => dest.TopicModel, opt => opt.MapFrom(src => src.Topic))
            // .IncludeMembers(q=>q.Answers)
            // .IncludeMembers(q=>q.Topic)     
     
            ;
        
        CreateMap<Topic, TopicModel>()
            .ForMember(dest => dest.QuestionModels, opt => opt.MapFrom(src => src.Questions))
            // .IncludeMembers(t=>t.Questions)
            ;
        

    }
}
