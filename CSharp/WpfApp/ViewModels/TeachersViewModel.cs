using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class TeachersViewModel : PeopleViewModel<Teacher, ITeachersService>
    {
        protected override ITeachersService Service => new TeachersService(Properties.Settings.Default.WebApi);

        protected override Teacher CreatePerson()
        {
            return new Teacher();
        }

        //protected override ObservableCollection<Person> InitPeople()
        //{
        //    return new ObservableCollection<Person> {
        //        new Teacher() { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1983, 1, 24), Gender = Gender.Female, Specialization = "Cooking" } ,
        //        new Teacher() { FirstName = "Maciek", LastName = "Maćkowski", BirthDate = new DateTime(1990, 7, 12), Gender = Gender.Male, Specialization = "Writer" }
        //    };
        //}
    }
}
