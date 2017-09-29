using System.Net;
using HomeKookd.DataAccess.HomeKookdMainContext.Enities;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess
{
    public class HomeKookdMainDataContext : DbContext
    {

        public HomeKookdMainDataContext(DbContextOptions<HomeKookdMainDataContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Kook> Kooks { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Meal> Meals { get; set; }

        public DbSet<Testimony> Testimonies { get; set; }
        public DbSet<MealReview> MealReviews { get; set; }


    }
}
