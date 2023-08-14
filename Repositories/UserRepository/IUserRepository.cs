using backend.Entities;

namespace backend.Repositories.UserRepository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetUserByToken(int userId, string email);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newUserDetails"></param>
        /// <returns></returns>
        Task<bool> UpdateUserProfile(User user, User newUserDetails);
    }
}