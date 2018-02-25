using System.ComponentModel.DataAnnotations;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class CryptoCurrencyPaymentDetails : PaymentDetails
    {
        [Required]
        public string WalletAddress { get; set; }
    }
}