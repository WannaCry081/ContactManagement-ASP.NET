using backend.Entities;
using backend.Entities.Types;

namespace backend.Services.ContactLogService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactLogService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="contact"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task LogContact(User user, Contact contact, string description, ContactEventType type);
    }
}