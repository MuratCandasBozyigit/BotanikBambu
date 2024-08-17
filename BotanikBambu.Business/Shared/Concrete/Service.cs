using BotanikBambu.Business.Shared.Abstract;
using BotanikBambu.Models;
using BotanikBambu.Repository.Shared.Abstract;
using System.Linq.Expressions;

public class Service<T> : IService<T> where T : BaseModel
{
    private readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public T Add(T entity)
    {
        return _repository.Add(entity);
    }

    public bool Delete(int id)
    {
        // Eğer IRepository'de int silme metodu varsa
        return _repository.Delete(id);
    }

    public bool Delete(Guid guid)
    {
        return _repository.Delete(guid);
    }

    public ICollection<T> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public ICollection<T> GetAll(Expression<Func<T, bool>> expression)
    {
        return _repository.GetAll(expression).ToList();
    }

    public T GetById(int id)
    {
        return _repository.GetById(id);
    }


    public T GetById(Guid id)
    {
       
        return _repository.GetById(id);
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>> expression)
    {
        return _repository.GetFirstOrDefault(expression);
    }

    public T Update(T entity)
    {
        return _repository.Update(entity);
    }
}
