using backend.Entities;

namespace backend.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUserProfile();
    }
}