using backend.Entities;

namespace backend.Repositories.ContactLogRepository
{
    /// <summary>
    /// Represents a repository for managing contact log data.
    /// </summary>
    public interface IContactLogRepository
    {
        /// <summary>
        /// Adds a contact log record to the repository.
        /// </summary>
        /// <param name="contactLog">The contact log entity to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddContactLog(ContactLog contactLog);
    }
}
