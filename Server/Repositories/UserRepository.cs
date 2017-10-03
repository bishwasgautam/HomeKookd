using System;
using System.Linq;
using HomeKookd.DataAccess.HomeKookdMainContext;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;
using HomeKookd.Domain;
using HomeKookd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.Repositories
{
    public class UserRepository : RepositoryBase<UserDo, User>, IUserRepository
    {
        private readonly IConverter<UserDo, User> _converter;
        public HomeKookdMainDataContext DataContext { get; set; }
        public UserRepository(IDataContext dataContext, IConverter<UserDo, User> converter) : base(dataContext, converter)
        {
            _converter = converter;
            DataContext = (dataContext is HomeKookdMainDataContext)? (HomeKookdMainDataContext) dataContext 
                : throw new ArgumentException("Expected HomeKookdMainDataContext got something else..:(");
        }

        public override UserDo FindBy(int id)
        {
            var userEntity = DataContext.Set<User>().FirstOrDefault(u => u.Id == id);

            return _converter.ConvertToDomainType(userEntity);
        }

        public  UserDo FindBy(string email)
        {
            var userEntity = DataContext.Set<User>().FirstOrDefault(u => u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));

            return _converter.ConvertToDomainType(userEntity);
        }

        public UserDo FindBy(PhoneDo phone)
        {
            return GetWithMatchingGivenPhoneInfo(
                phone.CountryCode, phone.AreaCode, phone.PhoneNumber, phone.Extension);
        }

        public UserDo GetWithMatchingGiven((string firstName, string lastName, string city, DateTime birthday) userInfoTuple)
        {
            throw new NotImplementedException();
        }

        private UserDo GetWithMatchingGivenPhoneInfo(string countryCode, string areaCode, string phoneNumber, string extension)
        {
            var userEntity = DataContext.Set<User>().Include(u => u.Phones)
                .FirstOrDefault(u => u.Phones.Any(p => p.GetFullNumber("{0:##########}")
                    .Equals($"{countryCode}{areaCode}{phoneNumber}{extension}")));

            return _converter.ConvertToDomainType(userEntity);
        }

        public interface IUserRepository
    {
        UserDo FindBy(string email);
        UserDo FindBy(PhoneDo phone);
        UserDo FindByMatchingGiven((string firstName, string lastName, string city, DateTime birthday) userInfoTuple);
    }
}