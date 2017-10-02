
using System;
using FluentValidation.Results;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.Repositories.Interfaces
{
    public interface IRepository<TDomainType> where TDomainType : IDomainBase
    {
        TDomainType FindBy(int id, bool fromCache = true);
        void Add(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
        void Update(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
        void Delete(TDomainType domainObj, int? modifiedBy = null, DateTime? modifiedDate = null);
    }

    public interface IDomainBase : IIdentifyable
    {
        ValidationResult ValidationResult { get; set; }
    }
}
