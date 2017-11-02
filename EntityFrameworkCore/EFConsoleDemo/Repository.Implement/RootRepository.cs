using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EFConsoleDemo.Repository.Interface;

namespace EFConsoleDemo.Repository.Implement
{
    public class RootRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public RootRepository(DbContext context)
        {
            Context = context;
        }

        IQueryable<TEntity> IRepository<TEntity>.All()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        bool IRepository<TEntity>.Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }

        void IRepository<TEntity>.Create(TEntity t)
        {
            Context.Set<TEntity>().Add(t);
        }

        void IRepository<TEntity>.Delete(TEntity t)
        {
            Context.Set<TEntity>().Remove(t);
        }

        void IRepository<TEntity>.Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IRepository<TEntity>.Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        TEntity IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Update(TEntity t)
        {
            throw new NotImplementedException();
        }
    }
}