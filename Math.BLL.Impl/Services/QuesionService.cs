using AutoMapper;
using Entities;
using Math.BLL.Abstract.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;

namespace Math.BLL.Services;

public class QuesionService  : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public QuesionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
