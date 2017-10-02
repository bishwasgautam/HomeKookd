
using System;
using HomeKookd.Domain.Interfaces;

namespace HomeKookd.Repositories.Interfaces
{
    public interface IRepository<TDomainType> where TDomainType : IDomainBase
    {
        TDomainType FindBy(int id, bool fromCache = true);
        void Add(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
        void Update(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
        void Delete(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
    }
}
