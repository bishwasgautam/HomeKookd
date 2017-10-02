using FluentValidation.Results;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.Domain.Interfaces
{
    public interface IDomainBase : IIdentifyable
    {
        ValidationResult ValidationResult { get; set; }
    }
}
