using System;
using System.Collections.Generic;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using HomeKookd.DataAccess.HomeKookdMainContext.Enums;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class Meal :IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set; }
        public MealType Type { get; set; }
        public MealDetail MealDetail { get; set; }
        public IEnumerable<MealReview> MealReviews { get; set; }


        //FKs
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }

        public int KookId { get; set; }
        public Kook Kook { get; set; }
        
    }
}