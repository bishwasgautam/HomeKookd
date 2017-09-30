using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class MealAttribute : IAuditable
    {
        public int Id { get; set; }
        public string  Attribute { get; set; }
        public bool Flagged { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int MealDetailId { get; set; }
        public MealDetail MealDetail { get; set; }

    }
}