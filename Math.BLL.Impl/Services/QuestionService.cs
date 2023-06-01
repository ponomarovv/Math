using AutoMapper;
using Entities;
using Math.BLL.Abstract.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;

namespace Math.BLL.Services;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    private readonly ITopicService _topicService;

    public QuestionService(IUnitOfWork unitOfWork, IMapper mapper, ITopicService topicService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _topicService = topicService;
    }

    public async Task<ICollection<QuestionModel>> Get10RandomQuestions()
    {
        int n = 10;
        var allQuestions = await _unitOfWork.QuestionRepository.GetAllAsync(x => true);
        int count = allQuestions.Count;
        if (count < n) n = count;
        var tenQuestions = allQuestions.OrderBy(y => Guid.NewGuid()).Take(n);
        var questionModels = tenQuestions.Select(_mapper.Map<QuestionModel>).ToList();

        return questionModels;
    }

    public async Task<ICollection<QuestionModel>> GetQuestionsByTopic(string topic)
    {
        int taken = 10;
        var allQuestions = _unitOfWork.QuestionRepository.GetAllAsync(x => x.Topic.Text == topic).Result;
        int count = allQuestions.Count;
        if (count < taken) taken = count;
        var tenQuestions =  allQuestions.OrderBy(y => Guid.NewGuid()).Take(taken);
        var questionModels =  tenQuestions.Select(_mapper.Map<QuestionModel>).ToList();

        return questionModels;
    }



    public async Task<QuestionModel> CreateAsync(QuestionModel model)
    {
        Question entity = _mapper.Map<Question>(model);
        var newEntity = await _unitOfWork.QuestionRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<QuestionModel>(newEntity);
    }

    public async Task<List<QuestionModel>> GetAllAsync()
    {
        var result = await _unitOfWork.QuestionRepository.GetAllAsync(x => true);
        var resultMapped = result.Select(_mapper.Map<QuestionModel>).ToList();

        return resultMapped;
    }

    public async Task<QuestionModel> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
        var resultMapped = _mapper.Map<QuestionModel>(result);

        return resultMapped;
    }

    public async Task<bool> UpdateAsync(QuestionModel model)
    {
        if (model == null)
        {
            return false;
        }

        var entity = _mapper.Map<Question>(model);

        var result = await _unitOfWork.QuestionRepository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _unitOfWork.QuestionRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }
}
