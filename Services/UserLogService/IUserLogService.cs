using backend.Entities;
using backend.Entities.Types;

namespace backend.Services.UserLogService
{
    /// <summary>
    /// Represents a service for managing user log operations.
    /// </summary>
    public interface IUserLogService
    {
        /// <summary>
        /// Logs a user authentication event.
        /// </summary>
        /// <param name="user">The user for whom the event is logged.</param>
        /// <param name="description">The description of the event.</param>
        /// <param name="type">The type of the event.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task LogUserAuthentication(User user, string description, UserEventType type);
    }
}
