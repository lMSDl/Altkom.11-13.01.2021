using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    public abstract class PersonValidator<T> : AbstractValidator<T> where T : Person
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithName(Properties.Resources.FirstName);
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.BirthDate).LessThan(DateTime.Now).GreaterThan(new DateTime());

            RuleFor(x => x.Gender).IsInEnum();
        }
    }
}
