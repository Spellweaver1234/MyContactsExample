using System;
using System.IO;

namespace MyContacts.DAL.DataAccess
{
    public class DataAccessHelper
    {
        public ContactsData ContactsTable { get; set; }

        public DataAccessHelper()
        {
            var dbName = "MyContacts.db";
            var dbFolder = Environment.SpecialFolder.LocalApplicationData;
            var dbPath = Path.Combine(Environment.GetFolderPath(dbFolder), dbName);
            ContactsTable = new ContactsData(dbPath);
        }
    }
}