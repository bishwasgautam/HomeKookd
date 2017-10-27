using HomeKookd.DataAccess.HomeKookdAppIdentityContext.Entities;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess.HomeKookdAppIdentityContext
{
    public class AppIdentityContext : IdentityDbContext<AppUser>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {

        }
    }
}