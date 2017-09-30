using System;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class HomeKookdMeal
    {
        public int Id { get; set; }
        public DateTime KookdTime { get; set; }
        public HomeKookdMealSetting HomeKookdMealSetting { get; set; }

        //FKs
        public int KookdCalendarId { get; set; }
        public KookdCalendar KookdCalendar { get; set; }

    }
}