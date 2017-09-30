using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class KookdCalendar
    {
        public int Id { get; set; }
        public IEnumerable<HomeKookdMealPerDay> HomeKookdMealsPerDay { get; set; }

        [NotMapped]
        public IEnumerable<HomeKookdMeal> TodaysMeals => HomeKookdMealsPerDay
            .Where(m => m.KookdTime.Day.Equals(DateTime.UtcNow.Day)).Select(hkm => hkm.HomeKookdMeal);

        [NotMapped]
        public IEnumerable<HomeKookdMeal> WeeksMeals => HomeKookdMealsPerDay
            .Where(m => m.KookdTime < DateTime.UtcNow.AddDays(7) && m.KookdTime > DateTime.UtcNow).Select(hkm => hkm.HomeKookdMeal);

        [NotMapped]
        public IEnumerable<HomeKookdMeal> MonthsMeals => HomeKookdMealsPerDay
            .Where(m => m.KookdTime < DateTime.UtcNow.AddDays(30) && m.KookdTime > DateTime.UtcNow).Select(hkm => hkm.HomeKookdMeal);

    }
}