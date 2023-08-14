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
            var items = DataService.ContactsTable.GetItems();
            Contacts = Mapping(items);
            Debug.WriteLine($"{Contacts.Count} contacts loaded");
        }

        private ObservableCollection<Contact> Mapping(ObservableCollection<ContactDTO> items)
        {
            var contacts = new ObservableCollection<Contact>();
            foreach (var item in items)
            {
                contacts.Add(new Contact() { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName });
            }

            return contacts;
        }

        public void AddContact()
        {
            var newContact = new ContactDTO() { FirstName = "123", LastName = "123" };
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