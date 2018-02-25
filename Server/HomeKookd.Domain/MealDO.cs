using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;

namespace HomeKookd.Domain
{
    public class MealDO : DomainBase
    {
        public MealDO(int id) : base(id)
        {
        }
      
        public string Name { get; set; }
    
        public string Description { get; set; }
     
        public double Price { get; set; }
       
        public MealType Type { get; set; }
    }
}