using System;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using HomeKookd.DataAccess.HomeKookdMainContext.Enums;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class Phone: IAuditable
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