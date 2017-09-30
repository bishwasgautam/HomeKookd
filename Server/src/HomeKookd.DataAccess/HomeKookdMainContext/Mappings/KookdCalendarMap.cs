﻿using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Mappings
{
    public class KookdCalendarMap : IEntityTypeConfiguration<KookdCalendar>
    {
        public void Configure(EntityTypeBuilder<KookdCalendar> builder)
        {
            builder.HasMany(kc => kc.HomeKookdMealsPerDay)
                .WithOne(hpd => hpd.KookdCalendar)
                .HasForeignKey(hpd => hpd.KookdCalendarId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}