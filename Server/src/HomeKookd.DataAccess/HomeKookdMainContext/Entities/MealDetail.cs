using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("MealDetails")]
    public class MealDetail : IAuditable, IIdentifyable
    {
        public MealDetail()
        {
            Attributes = new HashSet<MealAttribute>();
        }
        public int Id { get; set; }

        //Ingredients (Comma separated - eg: Olive oil, Flour, Chicken)
        public string Ingredients { get; set; }
        public int TotalCalories { get; set; }
        public ICollection<MealAttribute> Attributes { get; set; } //has preservatives, cooked with alcohol, artificial coloring, fermented etc


        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}