using HomeKookd.DataAccess.HomeKookdMainContext.Enums;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using System;
using System.Collections.Generic;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class User : IAuditable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public UserType Type { get; set; }
        public string Image { get; set; }
        public IEnumerable<Testimony> Testimonies { get; set; }//written for others by this user
    }
}