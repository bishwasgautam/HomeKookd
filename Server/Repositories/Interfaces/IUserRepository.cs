using System;
using HomeKookd.Domain;

namespace HomeKookd.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserDo FindBy(string email);
        UserDo FindBy(PhoneDo phone);
        UserDo FindByMatchingGiven((string firstName, string lastName, string city, DateTime birthday) userInfoTuple);

        UserDo GetWithMatchingGivenPhoneInfo(string countryCode, string areaCode, string phoneNumber,
            string extension);
    }
}