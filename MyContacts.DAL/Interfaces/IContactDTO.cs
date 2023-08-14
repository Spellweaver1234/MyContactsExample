namespace MyContacts.DAL.Interfaces
{
    public interface IContactDTO
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
