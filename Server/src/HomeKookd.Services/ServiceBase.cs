using FluentValidation.Results;
using HomeKookd.Domain;
using HomeKookd.Infrastructure.Authentication;
using HomeKookd.Services.Interfaces;

namespace HomeKookd.Services
{
    public abstract class ServiceBase: IValidatable, IServiceBase
    {
        public IAuthenticationContext AuthenticationContext { get; set; }
        protected ServiceBase(IAuthenticationContext authContext)
        {
            AuthenticationContext = authContext;
            ValidationResult = new ValidationResult();
        }

        protected ServiceBase()
        {
            ValidationResult = new ValidationResult();
        }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
    }
}
