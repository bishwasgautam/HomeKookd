using Microsoft.AspNetCore.Identity;

namespace HomeKookd.DataAccess.HomeKookdAppIdentityContext.Entities
{
    public class AppRole : IdentityRole
    {
        public string Description { get; set; }

    }
}