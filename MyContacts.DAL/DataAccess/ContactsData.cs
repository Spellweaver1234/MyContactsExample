using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using MyContacts.DAL.DTO;

using SQLite;

namespace MyContacts.DAL
{
    public class ContactsData
    {
        private readonly SQLiteAsyncConnection connection;

        public ContactsData(string databasePath)
        {
            connection = new SQLiteAsyncConnection(databasePath);
        }

        public CreateTableResult CreateTable()
        {
            CreateTableResult createTableResult = CreateTableResult.Migrated;
            Task.Run(async () =>
            {
                createTableResult = await connection.CreateTableAsync<Contact>();
            }).Wait();

            return createTableResult;
        }

        public ObservableCollection<Contact> GetItems()
        {
            List<Contact> list = new List<Contact>();
            Task.Run(async () =>
            {
                list = await connection.Table<Contact>().ToListAsync();
            }).Wait();

            return new ObservableCollection<Contact>(list);
        }
        public Contact GetItem(int id)
        {
            Contact result = null;
            Task.Run(async () =>
            {
                result = await connection.GetAsync<Contact>(id);
            }).Wait();

            return result;
        }
        public int DeleteItem(Contact item)
        {
            int result = 0;
            Task.Run(async () =>
            {
                result = await connection.DeleteAsync(item); ;
            }).Wait();

            return result;
        }
        public int DeleteAllItems()
        {
            int result = 0;
            Task.Run(async () =>
            {
                result = await connection.DeleteAllAsync<Contact>();
            }).Wait();

            return result;
        }
        public int UpdateInsertItem(Contact item)
        {
            int result = 0;
            Task.Run(async () =>
            {
                if (item.Id != 0)
                    result = await connection.UpdateAsync(item);
                else
                    result = await connection.InsertAsync(item);
            }).Wait();

            return result;
        }
    }
}