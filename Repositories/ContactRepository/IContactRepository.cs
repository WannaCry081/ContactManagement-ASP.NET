using backend.Entities;

namespace backend.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<ICollection<Contact>> GetUserContacts(int userId);
        Task<Contact?> GetUserContact(int userId, int contactId);
        // Task<bool> AddUserContact();
        // Task<bool> UpdateUserContact();
        // Task<bool> DeleteUserContact();
    }
}