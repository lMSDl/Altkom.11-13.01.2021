using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    public class StudentValidator : PersonValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.IndexNumber).GreaterThanOrEqualTo(100000).LessThanOrEqualTo(999999);
        }
    }
}
