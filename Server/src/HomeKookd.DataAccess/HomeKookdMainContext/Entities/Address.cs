using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Addresses")]
    public class Address : IAuditable, IIdentifyable 
    {
        public Address()
        {
             CreatedDateTime = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public AddressType AddressType { get; set; }
        public ResidenceType ResidenceType { get; set; }

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