using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Meals")]
    public class Meal :IAuditable
    {
        public Meal()
        {
            MealReviews = new HashSet<MealReview>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set; }
        public MealType Type { get; set; }
        public MealDetail MealDetail { get; set; }
        public ICollection<MealReview> MealReviews { get; set; }


        //FKs
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }

        public int KookId { get; set; }
        public Kook Kook { get; set; }

        public int HomeKookdMealId { get; set; }
        public HomeKookdMeal HomeKookdMeal { get; set; }


    }
}