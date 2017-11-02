using System;
using System.Linq;
using System.Linq.Expressions;

namespace EFConsoleDemo.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        bool Contains(Expression<Func<TEntity, bool>> predicate);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        
        void Create(TEntity t);

        void Delete(TEntity t);
        void Delete(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity t);

    }
}