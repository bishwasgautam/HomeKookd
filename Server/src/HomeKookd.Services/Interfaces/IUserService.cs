using HomeKookd.Services.DTOs;

namespace HomeKookd.Services.Interfaces
{
    public interface IUserService
    {
        void AddNewUser(UserDto userDto);
        void Validate(UserDto userDto);
        bool IsUserActive(LoginDto dto);
    }
}