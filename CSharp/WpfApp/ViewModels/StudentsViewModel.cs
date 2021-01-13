using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfApp.Properties;

namespace WpfApp.ViewModels
{
    public class StudentsViewModel : PeopleViewModel<Student, ICrudService<Student>>
    {
        protected override ICrudService<Student> Service => new CrudService<Student>(Settings.Default.WebApi, "/api/Students");

        protected override Student CreatePerson()
        {
            return new Student();
        }

        //protected override ObservableCollection<Person> InitPeople()
        //{
        //    return new ObservableCollection<Person> {
        //        new Student() { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1983, 1, 24), Gender = Gender.Female, IndexNumber = 121221 } ,
        //        new Student() { FirstName = "Maciek", LastName = "Maćkowski", BirthDate = new DateTime(1990, 7, 12), Gender = Gender.Male, IndexNumber = 820391 }
        //    };
        //}
    }
}
