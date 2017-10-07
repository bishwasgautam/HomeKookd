using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("MealReview")]
    public class MealReview : IIdentifyable
    {
        [Key]
        public int Id { get; set; }
        public Testimony Testimony { get; set; }

        [Required]
        public int TasteIndex { get; set; } // 0 - 10
        [Required]
        public int TextureIndex { get; set; } // 0 - 10
        [Required]
        public int PriceWorthyIndex { get; set; } // 0 - 10

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }

        //FKs
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}