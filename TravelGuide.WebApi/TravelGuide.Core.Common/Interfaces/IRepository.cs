using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TravelGuide.Core.Common.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Get(object id);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        
        IQueryable<TEntity> Get();
        
        TEntity Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);
        
        TEntity Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);
        
        TEntity Delete(object id);
        
        TEntity Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);
    }
}