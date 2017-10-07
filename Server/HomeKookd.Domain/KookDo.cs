using System.Collections.Generic;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;

namespace HomeKookd.Domain
{
    public class KookDo : DomainBase
    {
        public KookDo(int id) : base(id)
        {
            this.Id = id;
            HomeKookdMeals = new List<HomeKookdMeal>();
            Kitchen = new List<Kitchen>();
            OfferedMeals = new List<Meal>();
            Testimonies = new List<Testimony>();
        }

        public int Id { get; set; }
        public User User { get; set; }

        public List<HomeKookdMeal> HomeKookdMeals { get; set; }

        public List<Kitchen> Kitchen { get; set; }

        public List<Meal> OfferedMeals { get; set; }

        public List<Testimony> Testimonies { get; set; }
    }
}
