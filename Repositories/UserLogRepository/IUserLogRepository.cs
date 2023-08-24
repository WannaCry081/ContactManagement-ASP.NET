using backend.Entities;

namespace backend.Repositories.UserLogRepository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserLogRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLog"></param>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <param name="userLog"></param>
        /// <returns></returns>
        Task AddUserLog(UserLog userLog);
    }
}