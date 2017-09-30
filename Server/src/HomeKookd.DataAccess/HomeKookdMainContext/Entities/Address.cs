using HomeKookd.DataAccess.HomeKookdMainContext.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class Address : IAuditable 
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public AddressType Type { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int UserId { get; set; }
        public User User { get; set; }

        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
      
    }
}