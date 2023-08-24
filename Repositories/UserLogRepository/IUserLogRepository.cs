using backend.Entities;

namespace backend.Repositories.UserLogRepository
{
    /// <summary>
    /// Represents a repository for managing user log data.
    /// </summary>
    public interface IUserLogRepository
    {
        /// <summary>
        /// Adds a user log record to the repository.
        /// </summary>
        /// <param name="userLog">The user log entity to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddUserLog(UserLog userLog);
    }
}
