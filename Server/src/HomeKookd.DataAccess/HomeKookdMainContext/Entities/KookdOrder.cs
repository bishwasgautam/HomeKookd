using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Orders")]
    public class KookdOrder : IAuditable, IIdentifyable
    {

        public KookdOrder()
        {
            HomeKookdMeals = new List<HomeKookdMeal>();
        }

        [Key]
        public int Id { get; set; }

        public int KookId { get; set; }               /*      Both Kook and UpdatedByUser      */
        public Kook Kook { get; set; }               /*          share              */
        public int OrderedByUserId { get; set; }   /*            this            */
        public User OrderedByUser { get; set; }  /*               order       */


        public ICollection<HomeKookdMeal> HomeKookdMeals { get; set; } //all homekookd meals for a kook

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDateTime { get; set; }


        public int? UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public bool IsActive { get; set; }

        public OrderPriceDetails OrderPriceDetails { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentInfo PaymentInfo { get; set; }

        [NotMapped]
        public double CostOfAllMeals => HomeKookdMeals.Sum(hkm => hkm.MealPrice);

        public bool IsOrderValid()
        {
            var kookIds = HomeKookdMeals?.Select(hkm => hkm.Meal).Select(m => m.KookId).Distinct().ToList();
            return  kookIds?.Count == 1 && kookIds.First().Equals(KookId);
        }
    }
}