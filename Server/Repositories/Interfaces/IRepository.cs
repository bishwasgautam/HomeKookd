
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using HomeKookd.Domain.Interfaces;

namespace HomeKookd.Repositories.Interfaces
{
    public interface IRepository<TDomainType, TDataBaseType> where TDomainType : IDomainBase where TDataBaseType : class,IIdentifyable, new()
    {
        TDomainType FindBy(int id);
        IQueryable<TDataBaseType> Select();
        IQueryable<TDataBaseType> SelectWith(params Expression<Func<TDataBaseType, object>>[] includeProperties);
        void Add(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
        void Update(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
        void Delete(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
    }
}
