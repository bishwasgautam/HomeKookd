using System.Collections.Generic;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess
{
    public class HomeKookdMainContext : DbContext
    {

        public HomeKookdMainContext(DbContextOptions<HomeKookdMainContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

    }

    public class User
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public UserType Type { get; set; }
        public string Image { get; set; }

    }

    public enum UserType
    {
        HomeKook,
        Consumer,
        Delivery,

        AppAdmin,
        Sudo
    }

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

    public class Phone
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public PhoneType Type { get; set; }

        public string GetFullNumber()
        {
            return $"{CountryCode}{AreaCode}-{PhoneNumber}";
        }

    }

    public enum PhoneType
    {
        Home,
        Business,
        Cell
    }

    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public AddressType Type { get; set; }
    }

    public enum AddressType
    {
        Home,
        Rental
    }

    public class Kitchen
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public Kook Kook { get; set; }
        public int Serves { get;set; }
        public string Description  { get; set; }
        
    }

    public class Kook
    {
        public int Id { get; set; }
        public User User { get; set; }
        public IEnumerable<Kitchen> Kitchen { get; set; }

        public IEnumerable<Testimony> Testomonies { get; set; }

    }

    public class Testimony
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public User User { get; set; }
    }

    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Kitchen Kitchen { get; set; }
        public Kook Kook { get; set; }

        public double Price { get; set; }
        public MealType Type { get; set; }
        public MealDetails Details { get; set; }
    }

    public class MealDetails
    {
        public int Id { get; set; }

        //Ingredients (Comma separated - eg: Olive oil, Flour, Chicken)
        public string Ingredients { get; set; }
        public int TotalCalories { get; set; }
        public IEnumerable<MealAttribute> Attributes { get; set; } //has preservatives, cooked with alcohol, artificial coloring, fermented etc
        

    }

    public class MealAttribute
    {
        public int Id { get; set; }
        public string  Attribute { get; set; }
        public bool Flagged { get; set; }
    }


    public enum MealType
    {
        NonVeg, //meat
        PisciTarian, //only fish
        Vegetarian, //with eggs and dairy
        Vegan //no eggs or dairy
    }

    public class MealReview
    {
        public int Id { get; set; }
        public Testimony Testimony { get; set; }
        public int TasteIndex { get; set; } // 0 - 10
        public int TextureIndex { get; set; } // 0 - 10
        public int PriceWorthyIndex { get; set; } // 0 - 10
    }
}
