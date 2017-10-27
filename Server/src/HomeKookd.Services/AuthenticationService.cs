using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HomeKookd.DataAccess.HomeKookdAppIdentityContext.Entities;
using HomeKookd.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HomeKookd.Services
{
    public class AuthenticationService : ServiceBase, IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IPasswordHasher<AppUser> passwordHasher) : base()
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }


        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<AppUser> FindByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public bool HasMatchingPassword(AppUser user, string userPasswordHash, string dtoPassword)
        {
            return  _passwordHasher.VerifyHashedPassword(user, userPasswordHash, dtoPassword) ==
                   PasswordVerificationResult.Success;
        }

        public async Task<IEnumerable<Claim>> GetClaimsAsync(AppUser user)
        {
            return await _userManager.GetClaimsAsync(user);
        }
    }
}