using AutoMapper;
using Entities;
using Math.BLL.Abstract.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;

namespace Math.BLL.Services;

public class AnswerService : IAnswerService
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public AnswerModel Create(AnswerModel model)
    {
        Answer? entity = _mapper.Map<Answer>(model);
        Answer newEntity = _unitOfWork.AnswerRepository.Add(entity);
        _unitOfWork.SaveChanges();

        return _mapper.Map<AnswerModel>(newEntity);
    }

    public List<AnswerModel> GetAll()
    {
        var result = _unitOfWork.AnswerRepository.GetAll(x => true).Select(_mapper.Map<AnswerModel>).ToList();

        // _unitOfWork.Dispose();
        return result;
    }

    public AnswerModel GetById(int id)
    {
        var result = _mapper.Map<AnswerModel>(_unitOfWork.AnswerRepository.GetById(id));

        // _unitOfWork.Dispose();
        return result;
    }

    public bool Update(AnswerModel model)
    {
        if (model == null)
        {
            return false;
        }

        var entity = _mapper.Map<Answer>(model);

        var result = _unitOfWork.AnswerRepository.Update(entity);
        _unitOfWork.SaveChanges();

        // _unitOfWork.Dispose();

        return result;
    }

    public bool Delete(int id)
    {
        var result = _unitOfWork.AnswerRepository.Delete(id);
        _unitOfWork.SaveChanges();


        // _unitOfWork.Dispose();

        return result;
    }
}
