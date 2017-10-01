using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("MealAttributes")]
    public class MealAttribute : IAuditable, IIdentifyable
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