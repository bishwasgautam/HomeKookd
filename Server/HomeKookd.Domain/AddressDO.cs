using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;

namespace HomeKookd.Domain
{
    public class AddressDO : DomainBase
    {
        public AddressDO(int id) : base(id)
        {
        }

        public string Street { get; set; }
        public string Apartment { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public AddressType AddressType { get; set; }

        public ResidenceType ResidenceType { get; set; }
    }
}