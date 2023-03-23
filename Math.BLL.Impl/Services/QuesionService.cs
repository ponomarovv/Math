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
        var allQuestions = _unitOfWork.QuestionRepository.GetAll(x => true).Select(_mapper.Map<QuestionModel>).ToList();

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

        var fromRepo = _unitOfWork.QuestionRepository.GetById(1);
        
        QuestionModel? q = _mapper.Map<QuestionModel>(fromRepo);
        
        Console.WriteLine(q.Text);

        Console.WriteLine(q.TopicModel.Text);
        //
        // // TODO I don't get answers with the question. I have to use Include somewhere. but where
        // foreach (var item in q.AnswerModels)
        // {
        //     Console.WriteLine(item.Text);
        //     Console.WriteLine(item.IsCorrect);
        //     Console.WriteLine();
        // }

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

    public QuestionModel Create(QuestionModel model)
    {
        Question? entity = _mapper.Map<Question>(model);
        Question newEntity = _unitOfWork.QuestionRepository.Add(entity);
        _unitOfWork.SaveChanges();

        return _mapper.Map<QuestionModel>(newEntity);
    }

    public List<QuestionModel> GetAll()
    {
        var result = _unitOfWork.QuestionRepository.GetAll(x => true).Select(_mapper.Map<QuestionModel>).ToList();

        // _unitOfWork.Dispose();
        return result;
    }

    public QuestionModel GetById(int id)
    {
        var result = _mapper.Map<QuestionModel>(_unitOfWork.QuestionRepository.GetById(id));

        // _unitOfWork.Dispose();
        return result;
    }

    public bool Update(QuestionModel model)
    {
        if (model == null)
        {
            return false;
        }

        var entity = _mapper.Map<Question>(model);

        var result = _unitOfWork.QuestionRepository.Update(entity);
        _unitOfWork.SaveChanges();

        // _unitOfWork.Dispose();

        return result;
    }

    public bool Delete(int id)
    {
        var result = _unitOfWork.QuestionRepository.Delete(id);
        _unitOfWork.SaveChanges();


        // _unitOfWork.Dispose();

        return result;
    }
}
