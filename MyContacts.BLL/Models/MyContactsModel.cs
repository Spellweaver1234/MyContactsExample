using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

using MyContacts.DAL.DataAccess;
using MyContacts.DAL.DTO;

namespace MyContacts.BLL.Models
{
    public class MyContactsModel
    {
        private DataAccessHelper DataService { get; }

        public ObservableCollection<Contact> Contacts { get; set; }

        public MyContactsModel(DataAccessHelper dataService)
        {
            DataService = dataService;
        }

        public void CreateContactsTable()
        {
            DataService.ContactsTable.CreateTable();
        }
        public void LoadContacts()
        {
            Contacts = DataService.ContactsTable.GetItems();
            Debug.WriteLine($"{Contacts.Count} contacts loaded");
        }
        public void AddContact()
        {
            var newContact = new Contact() { FirstName = "123", LastName = "123" };
            DataService.ContactsTable.UpdateInsertItem(newContact);
            LoadContacts();
        }
        public void DeleteAllContact()
        {
            var newContact = Contacts.FirstOrDefault();
            DataService.ContactsTable.DeleteAllItems();
            LoadContacts();
        }
    }
}