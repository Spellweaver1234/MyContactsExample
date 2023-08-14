using System.IO;

using MyContacts.DAL.Interfaces;
using MyContacts.Droid.Dependencys;

using Xamarin.Forms;

using Environment = System.Environment;


[assembly: Dependency(typeof(SQLite_Android))]
namespace MyContacts.Droid.Dependencys
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}