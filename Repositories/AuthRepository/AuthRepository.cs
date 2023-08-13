using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;
using Microsoft.Identity.Client;

namespace backend.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> IsUserExists(User user)
        {
            return await _context.Users.Where(
                (c) => c.UserName.Equals(user.UserName) &&
                    c.Email.Equals(user.Email)
            ).AnyAsync();
        }

        public async Task<bool> AddNewUser(User user)
        {
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(
                (c) => c.Email.Equals(email)
            );
        }
    }
}