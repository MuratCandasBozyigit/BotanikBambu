using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BotanikBambu.Models;

namespace BotanikBambu.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        List<T> AddRange(List<T> entities);
        T Update(T entity);
        bool Delete(int id);
        T GetById(int id);
        T GetById(Guid id);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        void Save();
        bool Delete(Guid guid);
    }
}
