using backend.Entities;
using System.Threading.Tasks;

namespace backend.Services.ContactLogService
{
    /// <summary>
    /// Represents a service for managing contact log operations.
    /// </summary>
    public interface IContactLogService
    {
        /// <summary>
        /// Logs a contact-related event.
        /// </summary>
        /// <param name="user">The user associated with the event.</param>
        /// <param name="description">The description of the event.</param>
        /// <param name="type">The type of the event.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task LogContact(User user, string description, string type);
    }
}
