using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("HomeKookdMeals")]
    public class HomeKookdMeal
    {
        public int Id { get; set; }
        public DateTime KookdTime { get; set; }
        public HomeKookdMealSetting HomeKookdMealSetting { get; set; }

        public Meal Meal { get; set; }

        [NotMapped]
        public double MealPrice => Meal.Price;

        //FKs
        public int KookId { get; set; }
        public Kook Kook { get; set; }
        public int KookdCalendarId { get; set; }
        public KookdMealCalendar KookdMealCalendar { get; set; }

    }
}