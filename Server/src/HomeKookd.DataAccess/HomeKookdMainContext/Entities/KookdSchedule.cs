using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class KookdSchedule
    {
        public int Id { get; set; }

        public DateTime ReadyAt { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public bool IsRecurring { get; set; }
        public RecurringFrequency RecurringFrequency { get; set; }
        public int?  EveryXDay { get; set; }

        [NotMapped]
        public bool IsLive
        {
            get
            {
                var now = DateTime.UtcNow;
                return now > StartDateTime && now < EndDateTime;
            }
        }

        //FKs
        public int HomeKookdMealId { get; set; }
        public HomeKookdMeal HomeKookdMeal { get; set; }

    }
}