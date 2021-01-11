using Models;
using System;
using System.Collections.Generic;

namespace WpfApp.ViewModels
{
    public class StudentsViewModel
    {
        public StudentsViewModel()
        {
            Students = new List<Student> {
                new Student() { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1983, 1, 24), Gender = Gender.Female, IndexNumber = 121221 } ,
                new Student() { FirstName = "Maciek", LastName = "Maćkowski", BirthDate = new DateTime(1990, 7, 12), Gender = Gender.Male, IndexNumber = 820391 }
            };
        }

        public ICollection<Student> Students { get; set; }


    }
}
