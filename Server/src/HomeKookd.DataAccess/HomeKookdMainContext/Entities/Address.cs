using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
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

        [Key]
        public int Id { get; set; }
        [Required]
        public string Street { get; set; }
        public string Apartment { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public AddressType AddressType { get; set; }
        [Required]
        public ResidenceType ResidenceType { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int UserId { get; set; }
        public User User { get; set; }

        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
      
    }
}