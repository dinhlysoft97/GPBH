using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GPBH.Data
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);
        IQueryable<T> GetQueryable();
        IQueryable<T> Include(Expression<Func<T, object>> includeExpression);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includeExpressions);
    }
}
