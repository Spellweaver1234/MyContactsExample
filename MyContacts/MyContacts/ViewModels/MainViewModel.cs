using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

using MyContacts.BLL.Helpers;
using MyContacts.BLL.Models;
using MyContacts.DAL.DTO;

using Xamarin.Forms;

namespace MyContacts.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        MyContactsModel model;

        public Command AddContactCommand => new Command(AddContactAction);
        public Command DeleteAllContactCommand => new Command(DeleteAllContactAction);

        private void AddContactAction(object obj)
        {
            model.AddContact();
            Contacts = model.Contacts;
        }
        private void DeleteAllContactAction(object obj)
        {
            model.DeleteAllContact();
            Contacts = model.Contacts;
        }

        public MainViewModel()
        {
            model = BusinessLogicHelper.GetModel();

            Task.Run(() =>
            {
                model.CreateContactsTable();
                model.LoadContacts();
            }).Wait();

            Contacts = model.Contacts;
        }

        private ObservableCollection<Contact> contacts;
        public ObservableCollection<Contact> Contacts
        {
            get => contacts;
            set
            {
                contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
