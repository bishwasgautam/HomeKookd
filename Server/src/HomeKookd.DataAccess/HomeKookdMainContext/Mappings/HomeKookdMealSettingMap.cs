using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class HomeKookdMealSettingMap : IEntityTypeConfiguration<HomeKookdMealSetting>
    {
        public void Configure(EntityTypeBuilder<HomeKookdMealSetting> builder)
        {
            builder.HasOne(hkms => hkms.KookdSchedule)
                .WithOne(ks => ks.HomeKookdMealSetting)
                .HasForeignKey<KookdSchedule>(ks => ks.HomeKookdMealSettingId);
        }
    }
}