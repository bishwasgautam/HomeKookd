using System;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class HomeKookdMealPerDay
    {
        public int Id { get; set; }
        public DateTime KookdTime { get; set; }
        public HomeKookdMeal HomeKookdMeal { get; set; }

        //FKs
        public int KookdCalendarId { get; set; }
        public KookdCalendar KookdCalendar { get; set; }

    }
}