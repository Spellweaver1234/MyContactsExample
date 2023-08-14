using System.ComponentModel.DataAnnotations;

using MyContacts.DAL.Interfaces;

namespace MyContacts.DAL.DTO
{
    public class Contact : IContactDTO
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
