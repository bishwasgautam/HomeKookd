using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class MealMap : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasOne(m => m.Kitchen)
                .WithMany(k => k.Meals)
                .HasForeignKey(m => m.KitchenId);

            builder.HasOne(m => m.Kook)
                .WithMany(k => k.OfferedMeals)
                .HasForeignKey(m => m.KitchenId);

            builder.HasOne(m => m.MealDetail)
                .WithOne(md => md.Meal)
                .HasForeignKey<MealDetail>(md => md.MealId);

            builder.HasMany(m => m.MealReviews)
                .WithOne(m => m.Meal)
                .HasForeignKey(m => m.MealId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}