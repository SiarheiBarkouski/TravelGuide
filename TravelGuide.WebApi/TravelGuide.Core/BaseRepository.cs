using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TravelGuide.Core
{
    public abstract class BaseRepository<TEntity> where TEntity : class
        //<TEntity> where TEntity : class
    {
        private readonly RepositoryContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(RepositoryContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected RepositoryContext Context => _context;
        protected DbSet<TEntity> DbSet => _dbSet;

        public virtual TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            var result = _dbSet.Where(filter);
            return result;
        }

        public virtual IQueryable<TEntity> Get()
        {
            var result = _dbSet.AsQueryable();
            return result;
        }

        public virtual TEntity Add(TEntity entity)
        {
            var result = _dbSet.Add(entity);
            return result.Entity;
        }
        public virtual void Add(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual TEntity Update(TEntity entity)
        {
            var result = _dbSet.Update(entity);
            return result.Entity;
        }
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual TEntity Delete(object id)
        {
            var entity = _dbSet.Find(id);
            var result = _dbSet.Remove(entity);
            return result.Entity;
        }

        public virtual TEntity Delete(TEntity entity)
        {
            var result = _dbSet.Remove(entity);
            return result.Entity;
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}