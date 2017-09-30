using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class KookMap : IEntityTypeConfiguration<Kook>
    {
        public void Configure(EntityTypeBuilder<Kook> builder)
        {
            builder.HasMany(p => p.Kitchen)
                .WithOne(p => p.Kook)
                .HasForeignKey(p => p.KookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.HomeKookdMeals)
                .WithOne(p => p.Kook)
                .HasForeignKey(p => p.KookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Testomonies)
                .WithOne(p => p.Kook)
                .HasForeignKey(p => p.KookId)
                .OnDelete(DeleteBehavior.ClientSetNull); //KookId will be set to null, rest of the record stays intact
        }
    }
}