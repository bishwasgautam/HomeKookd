using System.Collections.Generic;

namespace HomeKookd.DataAccess
{
    public class Person
    {
        public int Id { get; set; }   
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
    }
}