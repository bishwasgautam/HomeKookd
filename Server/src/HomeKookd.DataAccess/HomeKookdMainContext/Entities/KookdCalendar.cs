using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class KookdCalendar
    {
        public int Id { get; set; }
        public IEnumerable<HomeKookdMeal> HomeKookdMealsPerDay { get; set; }

        [NotMapped]
        public IQueryable<HomeKookdMealSetting> TodaysMeals => HomeKookdMealsPerDay
            .Where(m => m.KookdTime.Day.Equals(DateTime.UtcNow.Day)).Select(hkm => hkm.HomeKookdMealSetting).AsQueryable();

        [NotMapped]
        public IQueryable<HomeKookdMealSetting> WeeksMeals => HomeKookdMealsPerDay
            .Where(m => m.KookdTime < DateTime.UtcNow.AddDays(7) && m.KookdTime > DateTime.UtcNow).Select(hkm => hkm.HomeKookdMealSetting).AsQueryable();

        [NotMapped]
        public IQueryable<HomeKookdMealSetting> MonthsMeals => HomeKookdMealsPerDay
            .Where(m => m.KookdTime < DateTime.UtcNow.AddDays(30) && m.KookdTime > DateTime.UtcNow).Select(hkm => hkm.HomeKookdMealSetting).AsQueryable();

    }
}