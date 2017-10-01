using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("KookdSchedules")]
    public class KookdSchedule
    {
        public int Id { get; set; }

        public DateTime ReadyAt { get; set; }
        public bool? IsRecurring { get; set; }
        public int?  RecurringFrequencyInDays { get; set; }
        public DateTime RecurStartDateTime { get; set; }
        public DateTime RecurEndDateTime { get; set; } 

        [NotMapped]
        public bool IsLive
        {
            get
            {
                var now = DateTime.UtcNow;
                return now > RecurStartDateTime && now < RecurEndDateTime;
            }
        }

        //FKs
        public int HomeKookdMealSettingId { get; set; }
        public HomeKookdMealSetting HomeKookdMealSetting { get; set; }

    }
}