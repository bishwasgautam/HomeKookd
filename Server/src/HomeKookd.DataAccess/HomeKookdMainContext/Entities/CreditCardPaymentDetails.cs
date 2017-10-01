using System;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class CreditCardPaymentDetails : PaymentDetails
    {

        public Address BillingAddress { get; set; }
        public string CardNumber { get; set; }
        public DateTime Expiration { get; set; }
        public int SecurityCode { get; set; }
    }
}