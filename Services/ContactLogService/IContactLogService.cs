using backend.Entities;
using backend.Entities.Types;

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
        /// <param name="contact">The contact for whom the event is logged.</param>
        /// <param name="description">The description of the event.</param>
        /// <param name="type">The type of the event.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task LogContact(User user, Contact contact, string description, ContactEventType type);
    }
}
