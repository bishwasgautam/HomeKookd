using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.DataAccess.HomeKookdMainContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess.HomeKookdMainContext
{
    public class HomeKookdMainDataContext : DbContext
    {

        public HomeKookdMainDataContext(DbContextOptions<HomeKookdMainDataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new KookdCalendarMap());
            modelBuilder.ApplyConfiguration(new KitchenMap());
            modelBuilder.ApplyConfiguration(new KookMap());
            modelBuilder.ApplyConfiguration(new MealDetailMap());
            modelBuilder.ApplyConfiguration(new MealMap());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<HomeKookdMeal> HomeKookdMeals { get; set; }
        public DbSet<HomeKookdMealPerDay> HomeKookdMealsPerDay { get; set; }
        public DbSet<KookdCalendar> KookdCalendars { get; set; }
        public DbSet<KookdSchedule> KookdSchedules { get; set; }
        public DbSet<Kook> Kooks { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealDetail> MealDetails { get; set; }
        public DbSet<MealAttribute> MealAttributes { get; set; }
        public DbSet<Testimony> Testimonies { get; set; }
        public DbSet<MealReview> MealReviews { get; set; }

    }
}
