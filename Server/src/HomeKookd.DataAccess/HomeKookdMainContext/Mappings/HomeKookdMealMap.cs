using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class HomeKookdMealMap : IEntityTypeConfiguration<HomeKookdMeal>
    {
        public void Configure(EntityTypeBuilder<HomeKookdMeal> builder)
        {
            builder.HasOne(hpd => hpd.HomeKookdMealSetting)
                .WithOne(hkm => hkm.HomeKookdMeal);

        }
    }
}