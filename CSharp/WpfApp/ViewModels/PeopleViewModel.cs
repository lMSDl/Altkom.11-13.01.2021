using Models;
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
    public abstract class PeopleViewModel<T> where T : Person
    {
        protected abstract ICrudService<T> Service { get; }

        public PeopleViewModel()
        {
            InitPeople();

            DeleteCommand = new CustomCommand(async x => await DeleteAsync(SelectedPerson), x => SelectedPerson != null);
            AddCommand = new CustomCommand(async x => await AddAsync());
            EditCommand = new CustomCommand(async x => await EditAsync(SelectedPerson), x => SelectedPerson != null);
        }

        private async Task DeleteAsync(T person)
        {
            await Service.DeleteAsync(person.Id);
            People.Remove(person);
        }

        public ObservableCollection<T> People { get; } = new ObservableCollection<T>();
        public T SelectedPerson { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        protected async void InitPeople()
        {
            if (Service == null)
                return;
            foreach (var person in await Service.ReadAsync())
                People.Add(person);
        }

        protected abstract T CreatePerson();

        private async Task AddAsync()
        {
            T item = CreatePerson();
            if (!ShowEditDialog(item))
            {
                return;
            }

            item = await Service.CreateAsync(item);
            People.Add(item);
        }

        private static bool ShowEditDialog(T item)
        {
            return new PersonDialogView(item).ShowDialog() == true;
        }

        private async Task EditAsync(T person)
        {
            T item = (T)person.Clone();

            if (!ShowEditDialog(item))
            {
                return;
            }

            await Service.UpdateAsync(item.Id, item);

            if (People.Contains(person))
                People.Remove(person);
            People.Add(item);
        }


    }
}
