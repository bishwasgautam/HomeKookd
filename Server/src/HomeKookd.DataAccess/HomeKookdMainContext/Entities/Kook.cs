using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Kooks")]
    public class Kook: IAuditable, IIdentifyable
    {

        public Kook()
        {
            HomeKookdMeals = new HashSet<HomeKookdMeal>();
            Kitchen = new List<Kitchen>();
            OfferedMeals = new HashSet<Meal>();
            Testimonies = new HashSet<Testimony>();
        }
        public int Id { get; set; }
        public User User { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        public ICollection<HomeKookdMeal> HomeKookdMeals { get; set; }

        public ICollection<Kitchen> Kitchen { get; set; }

        public ICollection<Meal> OfferedMeals { get; set; }

        public ICollection<Testimony> Testimonies { get; set; }


        [NotMapped]
        public IQueryable<Testimony> TopFiveTestimonies => Testimonies?.OrderByDescending(t => t.Rating).Take(5).AsQueryable();
        [NotMapped]
        public IQueryable<Testimony> BottomFiveTestimonies => Testimonies?.OrderByDescending(t => t.Rating).TakeLast(5).AsQueryable();

    }
}