using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;

namespace backend.Repositories.AuthRepository
{
    /// <summary>
    /// Repository class for user authentication operations.
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the `AuthRepository` class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <exception cref="ArgumentNullException">Thrown if the context is null.</exception>
        public AuthRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<bool> IsUserExists(User user)
        {
            return await _context.Users.Where(
                (c) => c.UserName.Equals(user.UserName) ||
                    c.Email.Equals(user.Email)
            ).AnyAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> AddNewUser(User user)
        {
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        /// <inheritdoc/>
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(
                (c) => c.Email.Equals(email)
            );
        }
    }
}