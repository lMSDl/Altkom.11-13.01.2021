using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class TeachersViewModel
    {
        public TeachersViewModel()
        {
            Teachers = new List<Teacher> {
                new Teacher() { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1983, 1, 24), Gender = Gender.Female, Specialization = "Cooking" } ,
                new Teacher() { FirstName = "Maciek", LastName = "Maćkowski", BirthDate = new DateTime(1990, 7, 12), Gender = Gender.Male, Specialization = "Writer" }
            };
        }

        public ICollection<Teacher> Teachers { get; set; }


    }
}
