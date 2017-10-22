using System.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess
{
    public interface IUnitOfWork<T> where T: DbContext
    {
        bool IsInTransaction { get; }
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        void RollBackTransaction();
        void CommitTransaction();
        void SaveChanges();
        //void Dispose();
    }
}
