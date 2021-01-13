using Microsoft.Win32;
using Models;
using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;
using Newtonsoft.Json.Linq;

namespace WpfApp.ViewModels
{
    public abstract class PeopleViewModel<T, TService> where T : Person where TService : ICrudService<T>
    {
        protected abstract TService Service { get; }

        public PeopleViewModel()
        {
            InitPeople();

            DeleteCommand = new CustomCommand(async x => await DeleteAsync(SelectedPerson), x => SelectedPerson != null);
            AddCommand = new CustomCommand(async x => await AddAsync());
            EditCommand = new CustomCommand(async x => await EditAsync(SelectedPerson), x => SelectedPerson != null);

            ImportCommand = new CustomCommand(async x => await ImportAsync());
            ExportCommand = new CustomCommand(x => Export(SelectedPerson), x => SelectedPerson != null);
        }

        private void Export(T selectedPerson)
        {
            var dialog = new SaveFileDialog()
            {
                Filter = ".json|*.json|.xml|*.xml|All|*.*",
                FileName = $"{SelectedPerson.LastName} {SelectedPerson.FirstName}"
            };

            if (dialog.ShowDialog() != true)
            {
                return;
            }

            var json = JsonConvert.SerializeObject(selectedPerson,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });

            switch (GetFileExtension(dialog.SafeFileName))
            {
                case ".json":
                    File.WriteAllText(dialog.FileName, json);
                    //using (var streamWriter = new StreamWriter(dialog.FileName))
                    //{
                    //    await streamWriter.WriteLineAsync(json);
                    //}
                    break;
                case ".xml":
                    var xml = JsonConvert.DeserializeXNode(json, typeof(T).Name);
                    xml.Save(dialog.FileName);
                    break;
                default:
                    return;
            }

        }

        private static string GetFileExtension(string safeFileName)
        {
            return safeFileName.Substring(safeFileName.LastIndexOf('.'));
        }

        private async Task ImportAsync()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = ".json|*.json|.xml|*.xml|All|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (dialog.ShowDialog() != true)
            {
                return;
            }

            T item;
            switch (GetFileExtension(dialog.SafeFileName))
            {
                case ".json":
                    var json = File.ReadAllText(dialog.FileName);
                    item = JsonConvert.DeserializeObject<T>(json);
                    break;
                case ".xml":
                    var xml = XDocument.Load(dialog.FileName);
                    item = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeXNode(xml, Formatting.None, true));
                    break;
                default:
                    return;
            }

            await AddAsync(item);
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
        public ICommand ImportCommand { get; set; }
        public ICommand ExportCommand { get; set; }

        protected async void InitPeople()
        {
            if (Service == null)
                return;
            foreach (var person in await Service.ReadAsync())
                People.Add(person);
        }

        protected abstract T CreatePerson();

        private async Task AddAsync(T item = null)
        {
            if(item == null)
                item = CreatePerson();
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
