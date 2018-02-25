using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using HomeKookd.Domain.Interfaces;
using HomeKookd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.Repositories
{
    public abstract class RepositoryBase<TDomainType, TDatabaseType> : IRepository<TDomainType, TDatabaseType>
        where TDomainType : class, IDomainBase where TDatabaseType : class, IIdentifyable, IAuditable, new()
    {
        private IDataContext _dataContext;
        private IConverter<TDomainType, TDatabaseType> _converter;

        protected RepositoryBase(IDataContext dataContext, IConverter<TDomainType, TDatabaseType> converter)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public IQueryable<TDatabaseType> Select()
        {
            return _dataContext.GetSet<TDatabaseType>();
        }

        public IQueryable<TDatabaseType> SelectWith(params Expression<Func<TDatabaseType, object>>[] includeProperties)
        {
            IQueryable<TDatabaseType> query = Select();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public abstract TDomainType FindBy(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainObj"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        public void Add(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null)
        {
            TDatabaseType entity = RetrieveDatabaseTypeFrom(domainObj, modifiedBy, modifiedDate);

            if (entity != null)
            {
                entity.CreatedDateTime = DateTime.UtcNow;
                entity.LastUpdatedDateTime = null;
                entity.IsActive = true;

                CreateSet().Add(entity); // adds the entire object graph
            }
               
        }

        /// <summary>
        /// This method assumes the domain object passed to it is complete and 
        /// updates all the direct properties on the entity. Does not update sub-collections 
        /// </summary>
        /// <param name="domainObj"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        public void Update(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null)
        {
            TDatabaseType entity = RetrieveDatabaseTypeFrom(domainObj, modifiedBy, modifiedDate);
            if (entity != null)
            {
                entity.LastUpdatedDateTime = DateTime.UtcNow;
                
                _dataContext.SetEntityState(entity, EntityState.Modified);
            }
               
        }

        public void Delete(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null)
        {
            TDatabaseType entity = RetrieveDatabaseTypeFrom(domainObj, modifiedBy, modifiedDate);
            if (entity != null)
            {
                //DataContext.Entry(entity).State = EntityState.Deleted;
                if (_dataContext.GetEntityState(entity) == EntityState.Detached)
                    CreateSet().Attach(entity);
                CreateSet().Remove(entity); // deletes the entire object graph
            }
        }

        protected TDatabaseType RetrieveDatabaseTypeFrom(IDomainBase domainBase, int? modifiedBy = null,
            DateTime? modifiedDate = null)
        {
            TDomainType domainObj = (TDomainType) domainBase;
            TDatabaseType entity = ConvertToDatabaseType(domainObj, modifiedBy, modifiedDate);
            return entity; // this entity is in a Detached state
        }

        public TDomainType ConvertToDomainType(TDatabaseType databaseType)
        {
            return _converter.ConvertToDomainType(databaseType);
        }

        public TDatabaseType ConvertToDatabaseType(TDomainType domainType, int? modifiedBy = null,
            DateTime? modifiedDate = null)
        {
            return _converter.ConvertToDatabaseType(domainType, modifiedBy, modifiedDate);
        }

        protected DbSet<TDatabaseType> CreateSet()
        {
            return _dataContext.GetSet<TDatabaseType>();
        }
    }
}

