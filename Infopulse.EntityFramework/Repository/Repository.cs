using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Infopulse.Core;
using Infopulse.EntityFramework.EntityFramework;

namespace Infopulse.EntityFramework.Repository
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
           where TEntity : Entity<TKey>
    {
        protected InfopulseDbContext Context;

        public Repository()
        {
            Context = new InfopulseDbContext();
        }

        public virtual TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(TKey publicId)
        {
            var entity = Context.Set<TEntity>().Find(publicId);
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public virtual bool SaveChanges()
        {
            return 0 < Context.SaveChanges();
        }
    }
}
