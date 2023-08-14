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
                createTableResult = await connection.CreateTableAsync<ContactDTO>();
            }).Wait();

            return createTableResult;
        }

        public ObservableCollection<ContactDTO> GetItems()
        {
            List<ContactDTO> list = new List<ContactDTO>();
            Task.Run(async () =>
            {
                list = await connection.Table<ContactDTO>().ToListAsync();
            }).Wait();

            return new ObservableCollection<ContactDTO>(list);
        }
        public ContactDTO GetItem(int id)
        {
            ContactDTO result = null;
            Task.Run(async () =>
            {
                result = await connection.GetAsync<ContactDTO>(id);
            }).Wait();

            return result;
        }
        public int DeleteItem(ContactDTO item)
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
                result = await connection.DeleteAllAsync<ContactDTO>();
            }).Wait();

            return result;
        }
        public int UpdateInsertItem(ContactDTO item)
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