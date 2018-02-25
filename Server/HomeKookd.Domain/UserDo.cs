using System;
using FluentValidation.Results;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities.Enums;
using HomeKookd.Domain.Interfaces;

namespace HomeKookd.Domain
{
    public class UserDo : DomainBase
    {
        public int Id { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public UserDo(int id) : base(id)
        {}

        public UserDo():base(0)
        {
            
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }

        public UserType Type { get; set; }
        public string Image { get; set; }
    }
}