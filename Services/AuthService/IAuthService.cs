using backend.Models.AuthModels;

namespace backend.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> SignUp(SignUpModel request);
        Task<string> SignIn(SignInModel request);
    }
}