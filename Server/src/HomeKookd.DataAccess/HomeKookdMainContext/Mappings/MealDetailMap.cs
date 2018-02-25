using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class MealDetailMap : IEntityTypeConfiguration<MealDetail>
    {
        public void Configure(EntityTypeBuilder<MealDetail> builder)
        {
            builder.HasMany(md => md.Attributes)
                .WithOne(ma => ma.MealDetail)
                .HasForeignKey(ma => ma.MealDetailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}