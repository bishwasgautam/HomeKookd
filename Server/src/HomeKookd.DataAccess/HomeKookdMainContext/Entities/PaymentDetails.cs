using System.ComponentModel.DataAnnotations;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public abstract class PaymentDetails : IIdentifyable
    {
        [Key]
        public int Id  { get; set; }

        [Required]
        public PaymentMethod Method { get; set; }

        //FKs
        public int PaymentInfoId { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }
}