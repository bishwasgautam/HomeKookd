using System;
using System.Collections.Generic;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class Kook: IAuditable
    {
        public int Id { get; set; }
        public User User { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<HomeKookdMeal> HomeKookdMeals { get; set; }

        public IEnumerable<Kitchen> Kitchen { get; set; }

        public IEnumerable<Meal> Meals { get; set; }

        public IEnumerable<Testimony> Testomonies { get; set; }

    }
}