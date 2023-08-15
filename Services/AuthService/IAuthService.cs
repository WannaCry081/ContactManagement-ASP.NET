using backend.Models.AuthModels;

namespace backend.Services.AuthService
{
    /// <summary>
    /// Interface for authentication operations.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new user and returns an access token.
        /// </summary>
        /// <param name="request">The user registration information.</param>
        /// <returns>An access token if registration is successful.</returns>
        Task<string> SignUp(SignUpModel request);

        /// <summary>
        /// Authenticates a user and returns an access token.
        /// </summary>
        /// <param name="request">The user's sign-in information.</param>
        /// <returns>An access token if authentication is successful.</returns>
        Task<string> SignIn(SignInModel request);
    }
}
