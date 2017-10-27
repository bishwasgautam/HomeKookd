using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Phones")]
    public class Phone: IAuditable, IIdentifyable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string AreaCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }

        [Required]
        public PhoneType Type { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int UserId { get; set; }
        public User User { get; set; }

        public string GetFullNumber() => $"{CountryCode}{AreaCode}{PhoneNumber}";
        

        public string GetFullNumber(string format) => string.Format(format, CountryCode, AreaCode, PhoneNumber);
        


    }
}