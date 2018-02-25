using System;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess
{
    public interface IUnitOfWork : IDisposable
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
