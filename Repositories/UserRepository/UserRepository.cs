using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;

namespace backend.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User?> GetUserByToken(int userId, string email)
        {
            return await _context.Users.Where(
                (c) => c.Id.Equals(userId) && c.Email.Equals(email)
            ).FirstOrDefaultAsync();
        }

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