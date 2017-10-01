using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public abstract class PaymentDetails : IIdentifyable
    {
        public int Id  { get; set; }
        public PaymentMethod Method { get; set; }

        //FKs
        public int PaymentInfoId { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }
}