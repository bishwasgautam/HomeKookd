using System;
using FluentValidation.Results;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.Domain;

namespace HomeKookd.Services.DTOs
{
    public class UserDto : IValidatable
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MiddleName { get; set; }
        public string Sex { get; set; }
        public UserType UserType { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagerUrl { get; set; }

        public ValidationResult ValidationResult { get; set; }
        
    }
}