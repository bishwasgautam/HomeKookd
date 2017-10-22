using System;
using System.Data;
using System.Linq;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeKookd.DataAccess
{
    public abstract class UnitOfWork<T>: IUnitOfWork<T>, IDisposable where T: DbContext
    {
        private IDbContextTransaction _transaction;
        private readonly T _dbContext;
        private bool _disposed;

        public bool IsInTransaction => _transaction != null;

        protected UnitOfWork(IDataContext dbContext)
        {
            _dbContext = (T) dbContext;
        }

        public void BeginTransaction()
        {
            if (_dbContext.ChangeTracker.Entries().Any(HasChanged))
            {
                throw new ApplicationException("Cannot begin a new transaction with existing pending changes not persisted to the database. " +
                                               "Save existing changes before beginning a transaction.");
            }

            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (IsInTransaction)
            {
                throw new ApplicationException("Cannot begin a new transaction while an existing transaction is still running. " +
                                               "Commit or rollback the existing transaction before starting a new one.");
            }

            _transaction = _dbContext.Database.BeginTransaction(isolationLevel); // this also opens the connection
        }

        public void RollBackTransaction()
        {
            if (!IsInTransaction)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            }

            try
            {
                _transaction.Rollback();
            }
            finally
            {
                ReleaseCurrentTransaction();
            }
        }

        public void CommitTransaction()
        {
            if (!IsInTransaction)
            {
                throw new ApplicationException("Cannot commit a transaction while there is no transaction running.");
            }

            try
            {
                SaveChangesIfTheyExist();
                _transaction.Commit();
            }
            catch
            {
                RollBackTransaction();
                throw;
            }
            finally
            {
                ReleaseCurrentTransaction();
            }
        }

        private void SetAuditiableProperties()
        {
            var entries = _dbContext.ChangeTracker.Entries<IAuditable>();
            foreach (var entry in entries)
            {
                if (entry.State.Equals(EntityState.Added))
                {
                    entry.Entity.CreatedDateTime = DateTime.UtcNow;
                    entry.Entity.LastUpdatedDateTime = DateTime.UtcNow;
                }
                else if (entry.State.Equals(EntityState.Modified))
                {
                    entry.Entity.LastUpdatedDateTime = DateTime.UtcNow;
                }
            }
        }

        /// <summary>
        /// The standard way of calling SaveChanges() is from Services using UnitOfWork.
        /// If database generated identity of the newly created entity is needed, then SaveChanges() can be called from Repositiories.
        /// </summary>
        public void SaveChanges()
        {
            if (IsInTransaction)
            {
                throw new ApplicationException("A transaction is running. Call CommitTransaction instead.");
            }

            SaveChangesIfTheyExist();
        }

        private void SaveChangesIfTheyExist()
        {
            if (_dbContext.ChangeTracker.Entries().Any(HasChanged))
            {
                SetAuditiableProperties();
                _dbContext.SaveChanges();
            }
        }

        private static bool HasChanged(EntityEntry entity)
        {
            return IsState(entity, EntityState.Added) || IsState(entity, EntityState.Modified) || IsState(entity, EntityState.Deleted);
        }

        private static bool IsState(EntityEntry entity, EntityState state)
        {
            return (entity.State & state) == state;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //make sure connection and transaction are disposed.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes off the managed and unmanaged resources used.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_disposed)
                return;

            ReleaseCurrentTransaction();
            //CloseConnection();

            _disposed = true;
        }

        private void OpenConnection()
        {
            if (_dbContext != null)
            {
                if (_dbContext.Database.GetDbConnection().State != ConnectionState.Open)
                    _dbContext.Database.GetDbConnection().Open();
            }
        }

        private void CloseConnection()
        {
            if (_dbContext != null)
            {
                if (_dbContext.Database.GetDbConnection().State != ConnectionState.Closed)
                    _dbContext.Database.GetDbConnection().Close();
            }
        }

        /// <summary>
        /// Releases the current transaction
        /// </summary>
        private void ReleaseCurrentTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose(); // this also closes the connection
                _transaction = null;
            }

        }
    }
}