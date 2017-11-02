using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EFConsoleDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace EFConsoleDemo.Repository.Implement
{
    public class RootRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public RootRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> All()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }

        public virtual void Create(TEntity t)
        {
            _context.Set<TEntity>().Add(t);
        }

        public virtual void Delete(TEntity t)
        {
            _context.Set<TEntity>().Remove(t);
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var item = Filter(predicate);
            foreach (var obj in item)
            {
                _context.Set<TEntity>().Remove(obj);
            }
            return _context.SaveChanges();
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate, out int total, int index = 0, int size = 50)
        {
            var skipCount = index * size;
            var resetSet = predicate != null
                ? _context.Set<TEntity>().Where<TEntity>(predicate).AsQueryable()
                : _context.Set<TEntity>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();

        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault<TEntity>(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return All().FirstOrDefault(predicate);
        }

        public virtual void Update(TEntity t)
        {
            try
            {
                var entry = _context.Entry(t);
                _context.Set<TEntity>().Attach(t);
                entry.State = EntityState.Modified;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}