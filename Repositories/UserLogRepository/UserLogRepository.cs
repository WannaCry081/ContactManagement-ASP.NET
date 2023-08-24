using backend.Data;
using backend.Entities;

namespace backend.Repositories.UserLogRepository
{
    /// <summary>
    /// Repository class for managing user log data.
    /// </summary>
    public class UserLogRepository : IUserLogRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is null.</exception>
        public UserLogRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task AddUserLog(UserLog userLog)
        {
            _context.UserLogs.Add(userLog);
            await _context.SaveChangesAsync();
        }
    }
}
