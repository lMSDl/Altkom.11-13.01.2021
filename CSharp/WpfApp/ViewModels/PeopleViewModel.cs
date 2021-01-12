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
    public abstract class PeopleViewModel
    {
        public PeopleViewModel()
        {
            People = InitPeople();

            DeleteCommand = new CustomCommand(x => People.Remove(SelectedPerson), x => SelectedPerson != null);
            AddCommand = new CustomCommand(x => AddOrEdit());
            EditCommand = new CustomCommand(x => AddOrEdit(SelectedPerson), x => SelectedPerson != null);
        }

        public ObservableCollection<Person> People { get; set; }
        public Person SelectedPerson { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        protected abstract ObservableCollection<Person> InitPeople();
        protected abstract Person CreatePerson();

        private void AddOrEdit(Person person = null)
        {
            Person item;
            if (person == null)
                item = CreatePerson();
            else
                item = (Person)person.Clone();

            var dialog = new PersonDialogView(item);
            if(dialog.ShowDialog() != true)
            {
                return;
            }

            if (People.Contains(person))
                People.Remove(person);
            People.Add(item);
        }

    }
}
