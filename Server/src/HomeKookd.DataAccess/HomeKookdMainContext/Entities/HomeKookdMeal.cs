using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("HomeKookdMeals")]
    public class HomeKookdMeal : IIdentifyable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime KookdTime { get; set; }

        public HomeKookdMealSetting HomeKookdMealSetting { get; set; }

        [Required]
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