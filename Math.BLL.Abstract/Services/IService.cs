namespace Math.BLL.Abstract.Services;

public interface IService<TModel> where TModel : class
{
    //  Create
    TModel Create(TModel model);

    // Read
    List<TModel> GetAll();
    TModel GetById(int id);

    // Update
    bool Update(TModel model);

    // delete
    bool Delete(int id);
}