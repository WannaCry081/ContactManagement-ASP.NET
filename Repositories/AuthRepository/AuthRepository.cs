using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;
using Microsoft.Identity.Client;

namespace backend.Repositories.AuthRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AuthRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> IsUserExists(User user)
        {
            return await _context.Users.Where(
                (c) => c.UserName.Equals(user.UserName) &&
                    c.Email.Equals(user.Email)
            ).AnyAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> AddNewUser(User user)
        {
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(
                (c) => c.Email.Equals(email)
            );
        }
    }
}