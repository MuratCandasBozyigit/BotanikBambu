using BotanikBambu.Models;
using BotanikBambu.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BotanikBambu.Data;
using Microsoft.AspNetCore.Http;
namespace BotanikBambu.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly int ownerAndUpdateId = 0;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Repository(ApplicationDbContext context, DbSet<T> dbSet, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _dbSet = dbSet;
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                ownerAndUpdateId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }







        public T Add(T entity)
        {
            entity.ModifierId = ownerAndUpdateId;
            entity.OwnerId = ownerAndUpdateId;

            _dbSet.Add(entity);
            Save();
            return entity;

        }

        public List<T> AddRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.ModifierId = ownerAndUpdateId;
                entity.OwnerId = ownerAndUpdateId;
            }
            _dbSet.AddRange(entities);
            Save();
            return entities;
        }

        public bool Delete(int id)
        {
            T entity = _dbSet.Find(id);
            entity.IsDeleted = true;

            entity.ModifierId = ownerAndUpdateId;
            entity.OwnerId = ownerAndUpdateId;
            Update(entity);
            return true;
        }

        public bool Delete(Guid guid)
        {
            T entity = _dbSet.Where(x => x.Guid == guid).FirstOrDefault();
            return Delete(entity.Id);
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
            entity.ModifierId = ownerAndUpdateId;
            entity.OwnerId = ownerAndUpdateId;
            _dbSet.Update(entity);


            Save();
            return entity;
        }
    }
}
