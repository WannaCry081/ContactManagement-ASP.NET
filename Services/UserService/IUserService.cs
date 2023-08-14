using backend.Models.UserModels;

namespace backend.Services.UserService
{
    public interface IUserService
    {
        Task<GetUserProfileModel> GetUserProfile();
    }
}