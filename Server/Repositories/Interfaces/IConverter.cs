using System;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using HomeKookd.Domain.Interfaces;

namespace HomeKookd.Repositories.Interfaces
{
    public interface IConverter<TDomainType, TDatabaseType> where TDomainType : IDomainBase
        where TDatabaseType : IIdentifyable, new()
    {
        TDatabaseType ConvertToDatabaseType(TDomainType domainType, int? modifiedBy, DateTime? modifiedDate);
        TDomainType ConvertToDomainType(TDatabaseType databaseType);
    }
}