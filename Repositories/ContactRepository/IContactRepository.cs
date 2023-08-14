using backend.Entities;

namespace backend.Repositories.ContactRepository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ICollection<Contact>> GetUserContacts(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task<Contact?> GetUserContact(int userId, int contactId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        Task<bool> CreateUserContact(Contact contact);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="newContactDetails"></param>
        /// <returns></returns>
        Task<bool> UpdateUserContact(Contact contact, Contact newContactDetails);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        Task<bool> DeleteUserContact(Contact contact);
    }
}