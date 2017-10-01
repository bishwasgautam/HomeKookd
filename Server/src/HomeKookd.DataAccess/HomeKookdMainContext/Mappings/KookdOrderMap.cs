using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class KookdOrderMap : IEntityTypeConfiguration<KookdOrder>
    {
        public void Configure(EntityTypeBuilder<KookdOrder> builder)
        {
            builder.HasOne(ko => ko.OrderedByUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(ko => ko.OrderedByUser);

            builder.HasOne(ko => ko.UpdatedByUser)
                .WithMany(u => u.UpdatedOrders)
                .HasForeignKey(ko => ko.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ko => ko.OrderPriceDetails)
                .WithOne(pi => pi.KookdOrder)
                .HasForeignKey<OrderPriceDetails>(opd => opd.KookdOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ko => ko.PaymentInfo)
                .WithOne(pi => pi.KookdOrder)
                .HasForeignKey<PaymentInfo>(pi => pi.KookdOrderId);

        }
    }
}