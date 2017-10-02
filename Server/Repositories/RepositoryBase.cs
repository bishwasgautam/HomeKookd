using System;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using HomeKookd.Domain.Interfaces;
using HomeKookd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.Repositories
{
    public abstract class RepositoryBase<TDomainType, TDatabaseType> : IRepository<TDomainType>
        where TDomainType : IDomainBase where TDatabaseType : class, IAuditable, IIdentifyable, new()
    {
        private IDataContext _dataContext;
        private IConverter<TDomainType, TDatabaseType> _converter;

        protected RepositoryBase(IDataContext dataContext, IConverter<TDomainType, TDatabaseType> converter)
        {
            this._dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            this._converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public abstract TDomainType FindBy(int id, bool fromCache = true);

        public void Add(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null)
        {
            TDatabaseType entity = RetrieveDatabaseTypeFrom(domainObj, modifiedBy, modifiedDate);
            if (entity != null)
                CreateSet().Add(entity); // adds the entire object graph
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
                _dataContext.SetEntityState(entity, EntityState.Modified);
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

    public interface IConverter<TDomainType, TDatabaseType> where TDomainType : IDomainBase
        where TDatabaseType : IIdentifyable, IAuditable, new()
    {
        TDatabaseType ConvertToDatabaseType(IDomainBase domainType, int? modifiedBy, DateTime? modifiedDate);
        TDomainType ConvertToDomainType(TDatabaseType databaseType);
    }

    
}
