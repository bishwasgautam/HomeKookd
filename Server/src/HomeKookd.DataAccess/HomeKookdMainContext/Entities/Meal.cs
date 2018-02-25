using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Meals")]
    public class Meal :IAuditable, IIdentifyable
    {
        public Meal()
        {
            MealReviews = new HashSet<MealReview>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public MealType Type { get; set; }
        public MealDetail MealDetail { get; set; }
        public ICollection<MealReview> MealReviews { get; set; }


        //FKs
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }

        public int KookId { get; set; }
        public Kook Kook { get; set; }

        public int HomeKookdMealId { get; set; }
        public HomeKookdMeal HomeKookdMeal { get; set; }


    }
}