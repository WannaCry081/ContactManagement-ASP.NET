using backend.Entities;
using backend.Models.UserModels;

namespace backend.Services.UserService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<User> GetUserByToken();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<GetUserProfileModel> GetUserProfile();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetUserProfileModel> UpdateUserProfile(UpdateUserProfileModel request);
    }
}