
using System;


namespace HomeKookd.DataAccess.HomeKookdAppIdentityContext.Entities
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public int UserId { get; set; }
        public DateTime JoinDate { get; set; }
    }
}