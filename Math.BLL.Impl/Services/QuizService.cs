using AutoMapper;
using Entities;
using Math.BLL.Abstract.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;

namespace Math.BLL.Services;

public class QuizService : IQuizService
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public QuizService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<QuizModel> CreateAsync(QuizModel model)
    {
        Quiz entity = _mapper.Map<Quiz>(model);
        Quiz newEntity = await _unitOfWork.QuizRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<QuizModel>(newEntity);
    }

    public async Task<List<QuizModel>> GetAllAsync()
    {
        var entities = await _unitOfWork.QuizRepository.GetAllAsync(x => true);
        var result = entities.Select(_mapper.Map<QuizModel>).ToList();

        return result;
    }

    public async Task<QuizModel> GetByIdAsync(int id)
    {
        var result = _mapper.Map<QuizModel>(await _unitOfWork.QuizRepository.GetByIdAsync(id));

        return result;
    }

    public async Task<bool> UpdateAsync(QuizModel model)
    {
        if (model == null)
        {
            return false;
        }

        var entity = _mapper.Map<Quiz>(model);

        var result = await _unitOfWork.QuizRepository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _unitOfWork.QuizRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }
}