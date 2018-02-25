using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("MealAttributes")]
    public class MealAttribute : IAuditable, IIdentifyable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Attribute { get; set; }
        public bool Flagged { get; set; }
        
        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDateTime { get; set; }

        public bool IsActive { get; set; }

        //FKs
        public int MealDetailId { get; set; }
        public MealDetail MealDetail { get; set; }

    }
}