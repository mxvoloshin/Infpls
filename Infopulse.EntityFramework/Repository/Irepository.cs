using System;
using System.Linq;
using System.Linq.Expressions;
using Infopulse.Core;

namespace Infopulse.EntityFramework.Repository
{
    public interface IRepository<TEntity, TKey>
          where TEntity : Entity<TKey>
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TKey id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        bool SaveChanges();
    }
}