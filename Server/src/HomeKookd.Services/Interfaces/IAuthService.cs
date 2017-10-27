using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HomeKookd.DataAccess.HomeKookdAppIdentityContext.Entities;
using Microsoft.AspNetCore.Identity;

namespace HomeKookd.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<AppUser> FindByNameAsync(string dtoUserName);
        bool HasMatchingPassword(AppUser user, string userPasswordHash, string dtoPassword);
        Task<IEnumerable<Claim>> GetClaimsAsync(AppUser user);
    }
}