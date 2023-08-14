using backend.Entities;

namespace backend.Repositories.AuthRepository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> IsUserExists(User user);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> AddNewUser(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetUserByEmail(string email);
    }
}