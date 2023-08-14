using backend.Entities;
using backend.Models.UserModels;

namespace backend.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUserByToken();
        Task<GetUserProfileModel> GetUserProfile();
        Task<GetUserProfileModel> UpdateUserProfile(UpdateUserProfileModel request);
    }
}