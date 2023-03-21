using Entities;
using Models;

namespace Math.BLL.Mappers;

public class MappersProfile : AutoMapper.Profile
{
    public MappersProfile()
    {
        CreateMap<Answer, AnswerModel>().ReverseMap();
        CreateMap<Question, QuestionModel>().ReverseMap();
        CreateMap<Topic, TopicModel>().ReverseMap();
    }
}
