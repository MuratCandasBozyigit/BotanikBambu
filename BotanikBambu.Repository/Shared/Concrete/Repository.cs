using BotanikBambu.Models;
using BotanikBambu.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using BotanikBambu.Data;

namespace BotanikBambu.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private int? _ownerAndUpdateId;

        public Repository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _httpContextAccessor = httpContextAccessor;

            var user = _httpContextAccessor.HttpContext?.User;

            if (user?.Identity?.IsAuthenticated == true)
            {
                _ownerAndUpdateId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }
        }

        public T Add(T entity)
        {
            if (_ownerAndUpdateId.HasValue)
            {
                entity.ModifierId = _ownerAndUpdateId.Value;
                entity.OwnerId = _ownerAndUpdateId.Value;
            }

            _dbSet.Add(entity);
            Save();
            return entity;
        }

        public List<T> AddRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (_ownerAndUpdateId.HasValue)
                {
                    entity.ModifierId = _ownerAndUpdateId.Value;
                    entity.OwnerId = _ownerAndUpdateId.Value;
                }
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
            if (_ownerAndUpdateId.HasValue)
            {
                entity.ModifierId = _ownerAndUpdateId.Value;
                entity.OwnerId = _ownerAndUpdateId.Value;
            }
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

        public T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Guid == id);
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
            if (_ownerAndUpdateId.HasValue)
            {
                entity.ModifierId = _ownerAndUpdateId.Value;
                entity.OwnerId = _ownerAndUpdateId.Value;
            }
            _dbSet.Update(entity);
            Save();
            return entity;
        }
    }
}
