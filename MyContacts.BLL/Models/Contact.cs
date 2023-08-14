using MyContacts.DAL.Interfaces;

namespace MyContacts.BLL.Models
{
    public class Contact : IContactDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
