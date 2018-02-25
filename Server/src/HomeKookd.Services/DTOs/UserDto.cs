
using System;
using System.ComponentModel.DataAnnotations;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.Domain;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace HomeKookd.Services.DTOs
{
    public class UserDto : IValidatable
    {

        public UserDto()
        {
            ValidationResult = new ValidationResult();
        }
        public int Id { get; set; }
        public bool IsValid => ValidationResult.Errors.Count == 0; 
        

        public string UserName { get; set; }

        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public UserType UserType { get; set; }

       
        [Url]
        [Required]
        public string ImageUrl { get; set; }
    
        public ValidationResult ValidationResult { get; set; }
        
    }
}