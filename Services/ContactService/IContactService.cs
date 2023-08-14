using backend.Entities;
using backend.Models.ContactModels;

namespace backend.Services.ContactService
{
    public interface IContactService
    {
        Task<ICollection<GetUserContactModel>> GetUserContacts(User user);
        Task<GetUserContactModel> GetUserContact(User user, int contactId);
        Task<GetUserContactModel> CreateUserContact(User user, UpsertUserContactModel request);
        Task<GetUserContactModel> UpdateUserContact(User user, UpsertUserContactModel request);
        Task<bool> DeleteUserContact(User user, int contactId);
    }
}