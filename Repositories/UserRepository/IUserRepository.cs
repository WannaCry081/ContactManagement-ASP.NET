using backend.Entities;

namespace backend.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByToken(int userId, string email);
    }
}