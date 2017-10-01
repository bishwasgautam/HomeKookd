using HomeKookd.DataAccess.HomeKookdMainContext.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        public Membership  Membership { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public UserType Type { get; set; }
        public string Image { get; set; }
        public ICollection<Testimony> Testimonies { get; set; }//written for others by this user
        public ICollection<PaymentInfo> PaymentInfo { get; set; }

        public ICollection<KookdOrder> Orders { get; set; } //all orders by UpdatedByUser
        public ICollection<KookdOrder> UpdatedOrders { get; set; } //Inverse property for KookdOrder.UpdatedByUserId
    }

    public enum MembershipStatus
    {
        PendingApplicationVerification,
        PendingAccountReview,
        Active,
        PaymentFailed,
        Compromised,
        InActive,
        Flagged
    }
}