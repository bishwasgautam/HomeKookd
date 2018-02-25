using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("PaymentInfo")]
    public class PaymentInfo: IIdentifyable
    {
        [Key]
        public int Id { get; set; }
        public PaymentDetails PaymentDetails { get; set; }

        //FKs
        public int KookdOrderId { get; set; }
        public  KookdOrder KookdOrder { get; set; }
    }
}