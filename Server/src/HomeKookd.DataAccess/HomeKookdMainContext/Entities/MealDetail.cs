using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.Collections.Generic;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class MealDetail : IAuditable
    {
        public int Id { get; set; }

        //Ingredients (Comma separated - eg: Olive oil, Flour, Chicken)
        public string Ingredients { get; set; }
        public int TotalCalories { get; set; }
        public IEnumerable<MealAttribute> Attributes { get; set; } //has preservatives, cooked with alcohol, artificial coloring, fermented etc


        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}