using backend.Entities;
using backend.Repositories.UserLogRepository;

namespace backend.Services.UserLogService
{
    /// <summary>
    /// Service class for managing user log operations.
    /// </summary>
    public class UserLogService : IUserLogService
    {
        private readonly IUserLogRepository _userLogRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogService"/> class.
        /// </summary>
        /// <param name="userLogRepository">The user log repository.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="userLogRepository"/> is null.</exception>
        public UserLogService(IUserLogRepository userLogRepository)
        {
            _userLogRepository = userLogRepository ?? throw new ArgumentNullException(nameof(userLogRepository));
        }

        /// <inheritdoc />
        public async Task LogUserAuthentication(User user, string description, string type)
        {
            var userLog = new UserLog()
            {
                UserId = user.Id,
                User = user,
                EventDescription = description,
                EventType = type
            };

            await _userLogRepository.AddUserLog(userLog);
        }
    }
}
