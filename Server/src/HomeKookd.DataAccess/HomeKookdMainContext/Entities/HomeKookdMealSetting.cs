using System;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("HomeKookdMealSettings")]
    public class HomeKookdMealSetting : IAuditable, IIdentifyable
    {
        public int Id { get; set; }

        public int  HeadCount { get; set; }
        public KookdSchedule KookdSchedule { get; set; }

        public DeliveryOption DeliveryOption { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int HomeKookdMealId { get; set; }
        public HomeKookdMeal HomeKookdMeal{ get; set; }



        [NotMapped]
        public bool IsPickedUp => DeliveryOption == DeliveryOption.Pickup;
        [NotMapped]
        public bool IsDelivered => DeliveryOption == DeliveryOption.Delivery;
        [NotMapped]
        public bool IsDineIn => DeliveryOption == DeliveryOption.DineIn;

        [NotMapped]
        public bool IsAvailable => KookdSchedule.IsLive;

    }
}


