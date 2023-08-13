using backend.Entities;

namespace backend.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        Task<bool> IsUserExists(User user);
        Task<bool> AddNewUser(User user);
    }
}