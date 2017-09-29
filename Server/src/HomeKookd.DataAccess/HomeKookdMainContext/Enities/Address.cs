namespace HomeKookd.DataAccess.HomeKookdMainContext.Enities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public AddressType Type { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        
    }
}