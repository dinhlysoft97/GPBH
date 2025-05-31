using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GPBH.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public T GetById(object id) => Context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => Context.Set<T>().ToList();

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().Where(predicate);

        public void Add(T entity) => Context.Set<T>().Add(entity);

        public void AddRange(IEnumerable<T> entities) => Context.Set<T>().AddRange(entities);

        public void Remove(T entity) => Context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => Context.Set<T>().RemoveRange(entities);

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
