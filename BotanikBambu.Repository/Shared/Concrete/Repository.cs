using BotanikBambu.Models;
using BotanikBambu.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using BotanikBambu.Data;
using Microsoft.AspNetCore.Http;

namespace BotanikBambu.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly int _ownerAndUpdateId;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Repository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _httpContextAccessor = httpContextAccessor;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                _ownerAndUpdateId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public T Add(T entity)
        {
            entity.ModifierId = _ownerAndUpdateId;
            entity.OwnerId = _ownerAndUpdateId;

            _dbSet.Add(entity);
            Save();
            return entity;
        }

        public List<T> AddRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.ModifierId = _ownerAndUpdateId;
                entity.OwnerId = _ownerAndUpdateId;
            }
            _dbSet.AddRange(entities);
            Save();
            return entities;
        }

        public bool Delete(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity == null)
                return false;

            entity.IsDeleted = true;
            entity.ModifierId = _ownerAndUpdateId;
            entity.OwnerId = _ownerAndUpdateId;
            Update(entity);
            return true;
        }

        public bool Delete(Guid guid)
        {
            T entity = _dbSet.FirstOrDefault(x => x.Guid == guid);
            return entity != null && Delete(entity.Id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            entity.ModifierId = _ownerAndUpdateId;
            entity.OwnerId = _ownerAndUpdateId;
            _dbSet.Update(entity);
            Save();
            return entity;
        }
    }
}
