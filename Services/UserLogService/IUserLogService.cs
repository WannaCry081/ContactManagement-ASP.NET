using backend.Entities;
using backend.Entities.Types;

namespace backend.Services.UserLogService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserLogService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task LogUserAuthentication(User user, string description, UserEventType type);
    }
}