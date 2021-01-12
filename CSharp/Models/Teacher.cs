using FluentValidation.Attributes;
using Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Validator(typeof(TeacherValidator))]
    public class Teacher : Person
    {
        public string Specialization { get; set; }
    }
}
