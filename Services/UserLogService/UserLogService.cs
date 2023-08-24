using backend.Entities;
using backend.Entities.Types;
using backend.Repositories.UserLogRepository;

namespace backend.Services.UserLogService
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLogService : IUserLogService
    {
        private readonly IUserLogRepository _userLogRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLogRepository"></param>
        public UserLogService(IUserLogRepository userLogRepository)
        {
            _userLogRepository = userLogRepository ?? throw new ArgumentNullException(nameof(userLogRepository));
        }

        /// <inheritdoc />
        public async Task LogUserAuthentication(User user, string description, UserEventType type)
        {
            var userLog = new UserLog() {
                UserId = user.Id,
                User = user,
                EventDescription = description,
                EventType = type
            };

            await _userLogRepository.AddUserLog(userLog);
        }
    }
}