﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class HomeKookdMealSetting : IAuditable
    {

        public int Id { get; set; }

        public int  HeadCount { get; set; }
        public KookdSchedule KookdSchedule { get; set; }

        public DeliveryOption DeliveryOption { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

       

        //FKs
        public HomeKookdMeal HomeKookdMeal{ get; set; }

        public int KookId { get; set; }
        public Kook Kook { get; set; }


        [NotMapped]
        public bool IsPickedUp => DeliveryOption == DeliveryOption.Pickup;
        [NotMapped]
        public bool IsDelivered => DeliveryOption == DeliveryOption.Delivery;
        [NotMapped]
        public bool IsDineIn => DeliveryOption == DeliveryOption.DineIn;

        [NotMapped]
        public bool IsAvailable => KookdSchedule.IsLive;

    }

    public class KookdOrder : IAuditable
    {
        public int Id { get; set; }

        public int OrderedByUserId { get; set; }
        public User OrderedByUser { get; set; }

        
        public IEnumerable<HomeKookdMeal> HomeKookdMeals { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }
    }

    public class KookdRequest : IAuditable
    {
        public int Id { get; set; }

        public int OrderedByUserId { get; set; }
        public User OrderedByUser { get; set; }


        public IEnumerable<HomeKookdMeal> HomeKookdMeals { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}