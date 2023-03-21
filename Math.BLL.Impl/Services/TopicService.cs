using AutoMapper;
using Entities;
using Math.BLL.Abstract.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;

namespace Math.BLL.Services;

public class TopicService  : ITopicService
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public TopicModel Create(TopicModel model)
    {
        Topic? entity = _mapper.Map<Topic>(model);
        Topic newEntity = _unitOfWork.TopicRepository.Add(entity);
        _unitOfWork.SaveChanges();

        return _mapper.Map<TopicModel>(newEntity);
    }

    public List<TopicModel> GetAll()
    {
        var result = _unitOfWork.TopicRepository.GetAll(x => true).Select(_mapper.Map<TopicModel>).ToList();

        // _unitOfWork.Dispose();
        return result;
    }

    public TopicModel GetById(int id)
    {
        var result = _mapper.Map<TopicModel>(_unitOfWork.TopicRepository.GetById(id));

        // _unitOfWork.Dispose();
        return result;
    }

    public bool Update(TopicModel model)
    {
        if (model == null)
        {
            return false;
        }

        var entity = _mapper.Map<Topic>(model);

        var result = _unitOfWork.TopicRepository.Update(entity);
        _unitOfWork.SaveChanges();

        // _unitOfWork.Dispose();

        return result;
    }

    public bool Delete(int id)
    {
        var result = _unitOfWork.TopicRepository.Delete(id);
        _unitOfWork.SaveChanges();


        // _unitOfWork.Dispose();

        return result;
    }
}
