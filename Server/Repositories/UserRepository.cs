using System;
using System.Linq;
using HomeKookd.DataAccess.HomeKookdMainContext;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.Domain;
using HomeKookd.Infrastructure.Authentication;
using HomeKookd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeKookd.Repositories
{
    public class UserRepository : RepositoryBase<UserDo, User>, IUserRepository
    {
        private readonly IConverter<UserDo, User> _converter;
        private readonly IAuthenticationContext _authContext;
        public HomeKookdMainDataContext DataContext { get; set; }

        public UserRepository(HomeKookdMainDataContext dataContext, IConverter<UserDo, User> converter, IAuthenticationContext authContext) : base(dataContext,
            converter)
        {
            _converter = converter;
            _authContext = authContext;
            DataContext =  dataContext;
        }

        public override UserDo FindBy(int id)
        {
            var userEntity = DataContext.Set<User>().FirstOrDefault(u => u.Id == id);

            return _converter.ConvertToDomainType(userEntity);
        }

        public UserDo FindBy(string email)
        {
            var userEntity = DataContext.Set<User>()
                .FirstOrDefault(u => u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));

            return _converter.ConvertToDomainType(userEntity);
        }

        public UserDo FindBy(PhoneDo phone)
        {
            return GetWithMatchingGivenPhoneInfo(
                phone.CountryCode, phone.AreaCode, phone.PhoneNumber, phone.Extension);
        }

        public UserDo FindByMatchingGiven(string firstName, string lastName, string city, DateTime? birthday)
        {
            var matchingRecords = DataContext.Set<User>().Include(x => x.Addresses).Where(x =>
                x.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase));

            var results = !string.IsNullOrEmpty(city) && matchingRecords.Count() > 1
                ? matchingRecords.Where(x =>
                    x.GetActiveAddress().City.Equals(city, StringComparison.CurrentCultureIgnoreCase)) : matchingRecords;

            var userEntity = birthday.HasValue && results.Count() > 1
                ? results.FirstOrDefault(x => x.BirthDate.Equals(birthday))
                : results.FirstOrDefault();

            return _converter.ConvertToDomainType(userEntity);
        }

        public int GetTestimoniesLeftByUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(UserDo userDo)
        {
            if (userDo.Id == 0)
            {
                Add(userDo, _authContext.UserId);
            }
        }

        public UserDo FindByEmail(string email)
        {
            return ConvertToDomainType(Select().FirstOrDefault(x => string.Equals(x.Email, email)));
        }

        //find first active user whose email or cell phone matches userName
        public UserDo FindByUsername(string userName)
        {
            var result = SelectWith(y => y.Phones).FirstOrDefault(x => x.IsActive && string.Equals(x.Email, userName,
                                                                           StringComparison.CurrentCultureIgnoreCase) ||  
                                                                       string.Equals(GetActiveCellPhoneNumber(x),  userName));
            return ConvertToDomainType(result);
        }

        private string GetActiveCellPhoneNumber(User u)
        {
            var phone = u.Phones.FirstOrDefault(p =>
                p.Type == PhoneType.Cell && p.IsActive);

            return phone?.GetFullNumber();
        }


        public UserDo GetWithMatchingGivenPhoneInfo(string countryCode, string areaCode, string phoneNumber,
            string extension)
        {
            var userEntity = DataContext.Set<User>().Include(u => u.Phones)
                .FirstOrDefault(u => u.Phones.Any(p => p.GetFullNumber("{0:##########}")
                    .Equals($"{countryCode}{areaCode}{phoneNumber}{extension}")));

            return _converter.ConvertToDomainType(userEntity);
        }
    }
}