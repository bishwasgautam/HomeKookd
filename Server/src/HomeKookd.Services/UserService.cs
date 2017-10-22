using FluentValidation.Results;
using HomeKookd.Domain;
using HomeKookd.Repositories;
using HomeKookd.Services.DTOs;
using HomeKookd.Services.Interfaces;

namespace HomeKookd.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddNewUser(UserDto userDto)
        {
            Validate(userDto);

            if (userDto.IsValid) {
                
                var userDO = new UserDo()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    MiddleName = userDto.MiddleName,
                    Sex = userDto.Sex,
                    Type = userDto.UserType,
                    BirthDate = userDto.BirthDate,
                    Image = userDto.ImagerUrl
                };

                _userRepository.Add(userDO);
            }
        }

        private void Validate(UserDto userDto)
        {
            //example
            userDto.ValidationResult.Errors.Add(new ValidationFailure("Test", "safasddas asfdasf sadfasdf")); 
        }

        public UserDto GetUserInfo(int phoneNumber)
        {
            var user = _userRepository.FindBy(GetPhoneDoFromNumber(phoneNumber));
           return new UserDto()
           {
               Id = user.Id,
               FirstName = user.FirstName,
               MiddleName = user.MiddleName,
               LastName = user.LastName,
               Email = user.Email,
               Sex = user.Sex,
               BirthDate = user.BirthDate,
               ImagerUrl = user.Image,
               UserType = user.Type
           };
        }

        private PhoneDo GetPhoneDoFromNumber(int phoneNumber)
        {
            var result = new PhoneDo();

            result.FormParts(phoneNumber.ToString());

            return result;
        }
    }
}
