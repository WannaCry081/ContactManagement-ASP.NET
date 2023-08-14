using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;

namespace backend.Repositories.UserRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User?> GetUserByToken(int userId, string email)
        {
            return await _context.Users.Where(
                (c) => c.Id.Equals(userId) && c.Email.Equals(email)
            ).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newUserDetails"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserProfile(User user, User newUserDetails) {
            user.FirstName = newUserDetails.FirstName;
            user.LastName = newUserDetails.LastName;
            user.UserName = newUserDetails.UserName;
            user.UpdatedAt = DateTime.Now;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}