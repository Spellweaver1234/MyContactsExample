using MyContacts.BLL.Models;
using MyContacts.DAL.DataAccess;

namespace MyContacts.BLL.Helpers
{
    public static class BusinessLogicHelper
    {
        private static MyContactsModel _model;

        public static MyContactsModel GetModel()
        {
            if (_model == null)
            {
                DataAccessHelper dataService = new DataAccessHelper();

                _model = new MyContactsModel(dataService);
            }

            return _model;
        }
    }
}
