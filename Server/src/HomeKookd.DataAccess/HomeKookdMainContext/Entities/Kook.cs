using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public IEnumerable<HomeKookdMealSetting> HomeKookdMeals { get; set; }

        public IEnumerable<Kitchen> Kitchen { get; set; }

        public IEnumerable<Meal> Meals { get; set; }

        public IEnumerable<Testimony> Testimonies { get; set; }


        [NotMapped]
        public IQueryable<Testimony> TopFiveTestimonies => Testimonies?.OrderByDescending(t => t.Rating).Take(5).AsQueryable();
        [NotMapped]
        public IQueryable<Testimony> BottomFiveTestimonies => Testimonies?.OrderByDescending(t => t.Rating).TakeLast(5).AsQueryable();

    }
}