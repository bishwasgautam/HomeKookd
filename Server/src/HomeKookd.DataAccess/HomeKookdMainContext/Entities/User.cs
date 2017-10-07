using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("KookdUsers")]
    public class User : IAuditable, IIdentifyable
    {
        public User()
        {
            Addresses = new List<Address>();
            Phones = new List<Phone>();
            Testimonies = new HashSet<Testimony>();
            PaymentInfo = new List<PaymentInfo>();
            CreatedDateTime = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDateTime { get; set; }

        public Membership  Membership { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Phone> Phones { get; set; }

        [Required]
        public UserType Type { get; set; }

        [Required]
        public string Image { get; set; }
        public ICollection<Testimony> Testimonies { get; set; }//written for others by this user
        public ICollection<PaymentInfo> PaymentInfo { get; set; }

        public ICollection<KookdOrder> Orders { get; set; } //all orders by UpdatedByUser
        public ICollection<KookdOrder> UpdatedOrders { get; set; } //Inverse property for KookdOrder.UpdatedByUserId

        public Address GetActiveAddress()
        {
            return Addresses?.FirstOrDefault(x => x.AddressType == AddressType.UserAddress && x.IsActive);
        }
    }
}