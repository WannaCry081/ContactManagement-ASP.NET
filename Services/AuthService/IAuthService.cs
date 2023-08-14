using backend.Models.AuthModels;

namespace backend.Services.AuthService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> SignUp(SignUpModel request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> SignIn(SignInModel request);
    }
}