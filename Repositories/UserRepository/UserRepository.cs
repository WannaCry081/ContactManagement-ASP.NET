using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;

namespace backend.Repositories.UserRepository
{
    /// <summary>
    /// Repository class for user operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the `UserRepository` class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <exception cref="ArgumentNullException">Thrown if the context is null.</exception>
        public UserRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<User?> GetUserByToken(int userId, string email)
        {
            return await _context.Users.Where(
                (c) => c.Id.Equals(userId) && c.Email.Equals(email)
            ).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
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