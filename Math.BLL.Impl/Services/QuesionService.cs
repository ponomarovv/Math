using System.Xml;
using AutoMapper;
using Entities;
using Math.BLL.Abstract.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;

namespace Math.BLL.Services;

public class QuesionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public QuesionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Dictionary<int, QuestionModel> Get20RandomQuestions()
    {
        // TODO how to get 20 random questions in ONE query? 

        // TODO Do I need to use Include and where?
        var allQuestions = _unitOfWork.QuestionRepository.GetAllAsync(x => true).Result.Select(_mapper.Map<QuestionModel>).ToList();

        var quizQuestions = new Dictionary<int, QuestionModel>();

        var rand = new Random();

        for (int i = 0; i < 20; i++)
        {
            while (true)
            {
                var key = rand.Next(1, allQuestions.Count + 1);
                if (quizQuestions.ContainsKey(key))
                {
                    // continue;
                }
                else
                {
                    quizQuestions.Add(key, allQuestions[key]);
                    break;
                }
            }
        }

        return quizQuestions;

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

