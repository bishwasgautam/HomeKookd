using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class PaymentInfoMap: IEntityTypeConfiguration<PaymentInfo>
    {
        public void Configure(EntityTypeBuilder<PaymentInfo> builder)
        {
            builder.HasOne(pi => pi.PaymentDetails)
                .WithOne(pd => pd.PaymentInfo)
                .HasForeignKey<PaymentDetails>(pd => pd.PaymentInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}