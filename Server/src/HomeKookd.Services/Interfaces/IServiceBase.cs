using HomeKookd.Infrastructure.Authentication;

namespace HomeKookd.Services.Interfaces
{
    public interface IServiceBase
    {
        IAuthenticationContext AuthenticationContext { get; set; }
    }
}