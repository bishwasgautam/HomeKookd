using System.Net;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess
{
    public class HomeKookdMainContext : DbContext
    {

        public HomeKookdMainContext(DbContextOptions<HomeKookdMainContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
