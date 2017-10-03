using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("OrderPriceDetails")]
    public class OrderPriceDetails : IIdentifyable
    {
        public int Id { get; set; }
        public decimal CalculatedTax { get; set; }
        public decimal TotalBeforeTax { get; set; }
        public decimal TotalAfterTax { get; set; }
        public decimal HomeKookdFees { get; set; }

        //FKs
        public int KookdOrderId { get; set; }
        public KookdOrder KookdOrder { get; set; }
    }
}