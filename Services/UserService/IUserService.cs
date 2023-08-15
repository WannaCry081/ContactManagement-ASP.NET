using backend.Entities;
using backend.Models.UserModels;

namespace backend.Services.UserService
{
    /// <summary>
    /// Service interface for user-related operations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves the user associated with the provided authentication token.
        /// </summary>
        /// <returns>The <see cref="User"/> associated with the token.</returns>
        Task<User> GetUserByToken();

        /// <summary>
        /// Retrieves the profile of the authenticated user.
        /// </summary>
        /// <returns>The <see cref="GetUserProfileModel"/> representing the user profile.</returns>
        Task<GetUserProfileModel> GetUserProfile();

        /// <summary>
        /// Updates the profile details of the authenticated user.
        /// </summary>
        /// <param name="request">The updated user profile details.</param>
        /// <returns>The <see cref="GetUserProfileModel"/> representing the updated user profile.</returns>
        /// <exception cref="Exception">Thrown when failed to update the user profile.</exception>
        Task<GetUserProfileModel> UpdateUserProfile(UpdateUserProfileModel request);
    }
}
