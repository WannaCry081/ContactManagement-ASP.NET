using backend.Entities;

namespace backend.Repositories.AuthRepository
{
    /// <summary>
    /// Interface for user authentication repository.
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Check if a user with the given details exists.
        /// </summary>
        /// <param name="user">The user to check.</param>
        /// <returns>Returns true if the user exists, false otherwise.</returns>
        Task<bool> IsUserExists(User user);

        /// <summary>
        /// Add a new user to the repository.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>Returns true if the user was added successfully.</returns>
        Task<bool> AddNewUser(User user);

        /// <summary>
        /// Get a user by their email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>Returns the user with the specified email, or null if not found.</returns>
        Task<User?> GetUserByEmail(string email);
    }
}
