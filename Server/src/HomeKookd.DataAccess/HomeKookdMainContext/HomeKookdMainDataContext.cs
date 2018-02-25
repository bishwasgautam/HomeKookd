using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using HomeKookd.DataAccess.HomeKookdMainContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess.HomeKookdMainContext
{
    //contains only DbContext implementation
    public partial class HomeKookdMainDataContext: DbContext
    {

        public HomeKookdMainDataContext(DbContextOptions<HomeKookdMainDataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new KookdCalendarMap());
            modelBuilder.ApplyConfiguration(new KitchenMap());
            modelBuilder.ApplyConfiguration(new KookMap());
            modelBuilder.ApplyConfiguration(new MealDetailMap());
            modelBuilder.ApplyConfiguration(new MealMap());
            modelBuilder.ApplyConfiguration(new HomeKookdMealMap());
            modelBuilder.ApplyConfiguration(new HomeKookdMealSettingMap());
            modelBuilder.ApplyConfiguration(new KookdOrderMap());
            modelBuilder.ApplyConfiguration(new PaymentInfoMap());

            modelBuilder.Entity<PaymentDetails>()
                .ToTable("PaymentDetails")
                .HasDiscriminator<string>("Discriminator")
                .HasValue<CreditCardPaymentDetails>("CC")
                .HasValue<CryptoCurrencyPaymentDetails>("Crypto");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<HomeKookdMealSetting> HomeKookdMealSettings { get; set; }
        public DbSet<HomeKookdMeal> HomeKookdMeals { get; set; }
        public DbSet<KookdMealCalendar> KookdMealCalendars { get; set; }
        public DbSet<KookdSchedule> KookdSchedules { get; set; }
        public DbSet<Kook> Kooks { get; set; }
        public DbSet<KookdOrder> KookdOrders { get; set; }
        public DbSet<OrderPriceDetails> OrderPriceDetails { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealDetail> MealDetails { get; set; }
        public DbSet<MealAttribute> MealAttributes { get; set; }
        public DbSet<MealReview> MealReviews { get; set; }
        public DbSet<Testimony> Testimonies { get; set; }
        public DbSet<PaymentInfo> PaymentInfo { get; set; }
        public DbSet<CreditCardPaymentDetails> CreditCardPaymentDetails { get; set; }
        public DbSet<CryptoCurrencyPaymentDetails> CryptoCurrencyPaymentDetails { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }

    //contains only IDataContext implementation
    public partial class HomeKookdMainDataContext :  IDataContext
    {
        public void SetEntityState(IIdentifyable entity, EntityState modified)
        {
            this.Entry(entity).State = modified;
        }

        public EntityState GetEntityState(IIdentifyable entity)
        {
            return Entry(entity).State;
        }

        public DbSet<T> GetSet<T>() where T : class, IIdentifyable, new()
        {
            return Set<T>();
        }
    }
}
