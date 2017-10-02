using System;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Phones")]
    public class Phone: IAuditable, IIdentifyable
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public PhoneType Type { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int UserId { get; set; }
        public User User { get; set; }

        public string GetFullNumber()
        {
            return $"{CountryCode}{AreaCode}{PhoneNumber}";
        }

        public string GetFullNumber(string format)
        {
            return string.Format(format, CountryCode, AreaCode, PhoneNumber);
        }


    }
}