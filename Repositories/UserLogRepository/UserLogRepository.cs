using backend.Data;
using backend.Entities;

namespace backend.Repositories.UserLogRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLogRepository : IUserLogRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserLogRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc /> 
        public async Task AddUserLog(UserLog userLog)
        {
            _context.UserLogs.Add(userLog);
            await _context.SaveChangesAsync();
        }
    }
}