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
    }
}
