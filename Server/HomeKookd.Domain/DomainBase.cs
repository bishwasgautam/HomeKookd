using System;
using FluentValidation.Results;
using HomeKookd.Domain.Interfaces;


namespace HomeKookd.Domain
{
    public class DomainBase : IDomainBase
    {
        public DomainBase(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            Id = id;

            ValidationResult = new ValidationResult();
        }
        public int Id { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
