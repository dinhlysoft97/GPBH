using System;
using System.Data;
using System.Linq.Expressions;

namespace GPBH.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class; 
        int SaveChanges();
        void BeginTransaction(IsolationLevel solationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
    }
}
