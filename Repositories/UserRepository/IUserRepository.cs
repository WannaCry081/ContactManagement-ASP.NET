using backend.Entities;

namespace backend.Repositories.UserRepository
{
    /// <summary>
    /// Repository interface for user operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a user by their token (userId and email).
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="email">The user's email.</param>
        /// <returns>The user if found, or null.</returns>
        Task<User?> GetUserByToken(int userId, string email);

        /// <summary>
        /// Updates a user's profile details.
        /// </summary>
        /// <param name="user">The user to be updated.</param>
        /// <param name="newUserDetails">The new user details.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateUserProfile(User user, User newUserDetails);
    }
}
