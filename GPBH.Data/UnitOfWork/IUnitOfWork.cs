using System;

namespace GPBH.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        int SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
