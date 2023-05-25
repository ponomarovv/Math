using System.Xml;
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

    public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ICollection<QuestionModel>> Get10RandomQuestions()
    {
        var allQuestions = await _unitOfWork.QuestionRepository.GetAllAsync(x => true);
        var tenQuestions = allQuestions.OrderBy(y => Guid.NewGuid()).Take(10);
        var questionModels = tenQuestions.Select(_mapper.Map<QuestionModel>).ToList();

        return questionModels;
    }

    public async Task<ICollection<QuestionModel>> GetQuestionsByTopic(string topic)
    {
        var allQuestions = _unitOfWork.QuestionRepository.GetAllAsync(x => x.Topic.Text == topic).Result;
        var tenQuestions =  allQuestions.OrderBy(y => Guid.NewGuid()).Take(10);
        var questionModels =  tenQuestions.Select(_mapper.Map<QuestionModel>).ToList();

        return questionModels;
    }

    public Task<ICollection<QuestionModel>> Get10RandomArithmeticQuestions()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<QuestionModel>> Get10RandomGeometryQuestions()
    {
        throw new NotImplementedException();
    }

    public void StartGame()
    {
        // var questions = Get20RandomQuestions();

        var fromRepo = _unitOfWork.QuestionRepository.GetByIdAsync(1);

        QuestionModel? q = _mapper.Map<QuestionModel>(fromRepo);

        Console.WriteLine(q.Text);

        Console.WriteLine(q.TopicModel.Text);
        //
        // // TODO I don't get answers with the question. I have to use Include somewhere. but where

        Console.WriteLine("Options: ");
        foreach (var item in q.AnswerModels)
        {
            Console.WriteLine(item.Text);
            Console.WriteLine(item.IsCorrect);
            Console.WriteLine();
        }

        // var answers = _unitOfWork.AnswerRepository.GetAll(x => x.Question.Id == 1).Select(_mapper.Map<AnswerModel>).ToList();
        //
        // foreach (var item in answers)
        // {
        //     Console.WriteLine(item.Id);
        //     Console.WriteLine(item.Text);
        //     Console.WriteLine(item.IsCorrect);
        //     Console.WriteLine();
        // }
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
