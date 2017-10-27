using System;
using FluentValidation.Results;
using HomeKookd.Domain;
using HomeKookd.Repositories;
using HomeKookd.Services.DTOs;
using HomeKookd.Services.Interfaces;
using HomeKookd.Resources;

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
            if (userDto.IsValid) {
                
                var userDo = new UserDo()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    MiddleName = userDto.MiddleName,
                    Sex = userDto.Sex,
                    Type = userDto.UserType,
                    BirthDate = userDto.BirthDate,
                    Image = userDto.ImageUrl
                };

                _userRepository.Add(userDo);
            }

        }

        public void Validate(UserDto userDto)
        {
            var user = _userRepository.FindByEmail(userDto.Email);
            if (user != null)
                userDto.ValidationResult.Errors.Add(new ValidationFailure(ValidationResource.FieldName.Email, ValidationResource.ErrorMessage.DuplicateEmail));
           
            var user1 = GetUserInfo(Convert.ToInt16(userDto.PhoneNumber));
            if(user1 != null)
                userDto.ValidationResult.Errors.Add(new ValidationFailure(ValidationResource.FieldName.PhoneNumber, ValidationResource.ErrorMessage.DuplicatePhoneNumber)); 
        }

        public bool IsUserActive(LoginDto dto)
        {
            var user = _userRepository.FindByUsername(dto.UserName);

            return user != null;
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
               ImageUrl = user.Image,
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
