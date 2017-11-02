using System;
using System.Linq;
using System.Linq.Expressions;
using EFConsoleDemo.Repository.Interface;

namespace EFConsoleDemo.Repository.Implement
{
    public class RootRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> IRepository<TEntity>.All()
        {
            throw new NotImplementedException();
        }

        bool IRepository<TEntity>.Contains(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Create(TEntity t)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Delete(TEntity t)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IRepository<TEntity>.Filter(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IRepository<TEntity>.Filter(Expression<Func<TEntity, bool>> predicate, out int total, int index, int size)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Find(params object[] keys)
        {
            throw new NotImplementedException();
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