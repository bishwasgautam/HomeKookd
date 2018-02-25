using System.Collections.Generic;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;

namespace HomeKookd.Domain
{
    public class KookDo : DomainBase
    {
        public KookDo(int id) : base(id)
        {
            HomeKookdMeals = new List<HomeKookdMealDo>();
            Kitchen = new List<KitchenDO>();
            SetOfferedMeals(new List<MealDO>());
            Testimonies = new List<TestimonyDo>();
        }

      
        public User User { get; set; }

        public List<HomeKookdMealDo> HomeKookdMeals { get; set; }

        public List<KitchenDO> Kitchen { get; set; }

        private List<MealDO> offeredMeals;

        public List<MealDO> GetOfferedMeals()
        {
            return offeredMeals;
        }

        public void SetOfferedMeals(List<MealDO> value)
        {
            offeredMeals = value;
        }

        public List<TestimonyDo> Testimonies { get; set; }
    }
}
