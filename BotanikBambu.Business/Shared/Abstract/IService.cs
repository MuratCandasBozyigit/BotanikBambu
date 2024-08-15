using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BotanikBambu.Models;
namespace BotanikBambu.Business.Shared.Abstract
{
    public interface IService<T> where T:BaseModel
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
        bool Delete(Guid guid);
        T GetFirstOrDefault(Expression<Func<T, bool>> expression);
        ICollection<T>GetAll(Expression<Func<T, bool>> expression);
    }
}
