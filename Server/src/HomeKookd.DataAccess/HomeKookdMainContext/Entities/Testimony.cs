using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Testimonies")]
    public class Testimony : IIdentifyable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }

        //FKs
        public int? UserId { get; set; } //By
        public User User { get; set; }

        public int? KookId { get; set; } //For
        public Kook Kook { get; set; }


    }
}