using System.ComponentModel.DataAnnotations;

namespace HomeKookd.Services.DTOs
{
    public class RegisterDto : UserDto
    {

        [Required]
        public string Password { get; set; }
    }

}