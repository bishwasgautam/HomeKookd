using System;
using System.ComponentModel.DataAnnotations;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class CreditCardPaymentDetails : PaymentDetails
    {
        [Required]
        public Address BillingAddress { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime Expiration { get; set; }
        [Required]
        public int SecurityCode { get; set; }
    }
}