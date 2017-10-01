using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class KitchenMap : IEntityTypeConfiguration<Kitchen>
    {
        public void Configure(EntityTypeBuilder<Kitchen> builder)
        {
            builder.HasOne(p => p.Address)
                .WithOne(p => p.Kitchen)
                .HasForeignKey<Address>(a => a.KitchenId);

            builder.HasOne(p => p.Kook)
                .WithMany(p => p.Kitchen)
                .HasForeignKey(p => p.KookId);

        }
    }
}