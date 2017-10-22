using System;
using HomeKookd.Domain;

namespace HomeKookd.Repositories
{
    public interface IUserRepository
    {
        UserDo FindBy(string email);
        UserDo FindBy(PhoneDo phone);
        UserDo FindByMatchingGiven(string firstName, string lastName, string city, DateTime? birthday);

        int GetTestimoniesLeftByUser(int id);

        void Add(UserDo userDo);
    }
}