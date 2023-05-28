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

    public async Task<AnswerModel> CreateAsync(AnswerModel model)
    {
        var entity = _mapper.Map<Answer>(model);
        var newEntity = _unitOfWork.AnswerRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var result = _mapper.Map<AnswerModel>(newEntity.Result);

        return result;
    }

    public async Task<List<AnswerModel>> GetAllAsync()
    {
        var entities = await _unitOfWork.AnswerRepository.GetAllAsync(x => true);
        var result = entities.Select(_mapper.Map<AnswerModel>).ToList();

        return result;
    }

    public async Task<AnswerModel> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.AnswerRepository.GetByIdAsync(id);
        var result = _mapper.Map<AnswerModel>(entity);

        return result;
    }

    public async Task<bool> UpdateAsync(AnswerModel model)
    {
        if (model == null)
        {
            return false;
        }

        var entity = _mapper.Map<Answer>(model);

        var result = await _unitOfWork.AnswerRepository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _unitOfWork.AnswerRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }
}
