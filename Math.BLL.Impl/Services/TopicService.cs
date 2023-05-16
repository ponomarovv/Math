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

    public async Task<TopicModel> CreateAsync(TopicModel model)
    {
        Topic entity = _mapper.Map<Topic>(model);
        Topic newEntity = await _unitOfWork.TopicRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<TopicModel>(newEntity);
    }

    public async Task<List<TopicModel>> GetAllAsync()
    {
        var entities = await _unitOfWork.TopicRepository.GetAllAsync(x => true);
        var result = entities.Select(_mapper.Map<TopicModel>).ToList();

        return result;
    }

    public async Task<TopicModel> GetByIdAsync(int id)
    {
        var result = _mapper.Map<TopicModel>(await _unitOfWork.TopicRepository.GetByIdAsync(id));

        return result;
    }

    public async Task<bool> UpdateAsync(TopicModel model)
    {
        if (model == null)
        {
            return false;
        }

        var entity = _mapper.Map<Topic>(model);

        var result = await _unitOfWork.TopicRepository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _unitOfWork.TopicRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return  result;
    }
}
