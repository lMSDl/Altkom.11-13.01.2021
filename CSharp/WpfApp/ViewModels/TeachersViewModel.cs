using Models;
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
    public class TeachersViewModel
    {
        public TeachersViewModel()
        {
            Teachers = new ObservableCollection<Teacher> {
                new Teacher() { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1983, 1, 24), Gender = Gender.Female, Specialization = "Cooking" } ,
                new Teacher() { FirstName = "Maciek", LastName = "Maćkowski", BirthDate = new DateTime(1990, 7, 12), Gender = Gender.Male, Specialization = "Writer" }
            };

            DeleteCommand = new CustomCommand(x => Teachers.Remove(SelectedTeacher), x => SelectedTeacher != null);
            AddCommand = new CustomCommand(x => AddOrEdit());
            EditCommand = new CustomCommand(x => AddOrEdit(SelectedTeacher), x => SelectedTeacher != null);
        }

        public ObservableCollection<Teacher> Teachers { get; set; }
        public Teacher SelectedTeacher { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        private void AddOrEdit(Teacher teacher = null)
        {
            Teacher item;
            if (teacher == null)
                item = new Teacher();
            else
                item = (Teacher)teacher.Clone();

            var dialog = new TeacherDialogView(item);
            if(dialog.ShowDialog() != true)
            {
                return;
            }

            if (Teachers.Contains(teacher))
                Teachers.Remove(teacher);
            Teachers.Add(item);
        }

    }
}
