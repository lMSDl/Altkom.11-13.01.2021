using FluentValidation.Attributes;
using Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Validator(typeof(StudentValidator))]
    public class Student : Person
    {
        public int IndexNumber { get; set; }

        public int? Class_Id { get; set; }
        public Class Class { get; set; }
    }
}
