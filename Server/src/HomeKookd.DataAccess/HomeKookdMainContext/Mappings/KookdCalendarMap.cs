using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class KookdCalendarMap : IEntityTypeConfiguration<KookdMealCalendar>
    {
        public void Configure(EntityTypeBuilder<KookdMealCalendar> builder)
        {
            builder.HasMany(kc => kc.HomeKookdMeals)
                .WithOne(hpd => hpd.KookdMealCalendar)
                .HasForeignKey(hpd => hpd.KookdCalendarId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}