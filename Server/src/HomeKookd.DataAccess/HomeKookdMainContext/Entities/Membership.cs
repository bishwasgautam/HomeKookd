using System;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Memberships")]
    public class Membership : IAuditable, IIdentifyable
    {
        public int Id { get; set; }
        public MembershipStatus Status { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime UserLastSeen { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public int UpdatedBy { get; set; }
        [ForeignKey("UpdatedByUserId")]
        public User User { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
    }
}