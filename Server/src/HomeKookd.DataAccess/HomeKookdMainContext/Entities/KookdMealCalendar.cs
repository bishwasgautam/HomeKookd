using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("MealCalendars")]
    public class KookdMealCalendar
    {
        public KookdMealCalendar()
        {
            HomeKookdMeals = new HashSet<HomeKookdMeal>();
        }
        public int Id { get; set; }
        public ICollection<HomeKookdMeal> HomeKookdMeals { get; set; }

        [NotMapped]
        public IQueryable<HomeKookdMealSetting> TodaysMeals => HomeKookdMeals
            .Where(m => m.KookdTime.Day.Equals(DateTime.UtcNow.Day)).Select(hkm => hkm.HomeKookdMealSetting).AsQueryable();

        [NotMapped]
        public IQueryable<HomeKookdMealSetting> WeeksMeals => HomeKookdMeals
            .Where(m => m.KookdTime < DateTime.UtcNow.AddDays(7) && m.KookdTime > DateTime.UtcNow).Select(hkm => hkm.HomeKookdMealSetting).AsQueryable();

        [NotMapped]
        public IQueryable<HomeKookdMealSetting> MonthsMeals => HomeKookdMeals
            .Where(m => m.KookdTime < DateTime.UtcNow.AddDays(30) && m.KookdTime > DateTime.UtcNow).Select(hkm => hkm.HomeKookdMealSetting).AsQueryable();

    }
}