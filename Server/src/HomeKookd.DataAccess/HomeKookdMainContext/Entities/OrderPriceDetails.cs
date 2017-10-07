using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("OrderPriceDetails")]
    public class OrderPriceDetails : IIdentifyable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal CalculatedTax { get; set; }

        [Required]
        public decimal TotalBeforeTax { get; set; }

        [Required]
        public decimal TotalAfterTax { get; set; }

        [Required]
        public decimal HomeKookdFees { get; set; }

        //FKs
        public int KookdOrderId { get; set; }
        public KookdOrder KookdOrder { get; set; }
    }
}