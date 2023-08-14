using backend.Entities;
using backend.Models.ContactModels;

namespace backend.Services.ContactService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ICollection<GetUserContactModel>> GetUserContacts(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task<GetUserContactModel> GetUserContact(User user, int contactId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetUserContactModel> CreateUserContact(User user, UpsertUserContactModel request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="contactId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetUserContactModel> UpdateUserContact(User user, int contactId, UpsertUserContactModel request);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task<bool> DeleteUserContact(User user, int contactId);
    }
}