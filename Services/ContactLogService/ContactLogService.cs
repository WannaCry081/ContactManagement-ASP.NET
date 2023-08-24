using backend.Entities;
using backend.Repositories.ContactLogRepository;

namespace backend.Services.ContactLogService
{
    /// <summary>
    /// Service class for managing contact log operations.
    /// </summary>
    public class ContactLogService : IContactLogService
    {
        private readonly IContactLogRepository _contactLogRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactLogService"/> class.
        /// </summary>
        /// <param name="contactLogRepository">The contact log repository.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="contactLogRepository"/> is null.</exception>
        public ContactLogService(IContactLogRepository contactLogRepository)
        {
            _contactLogRepository = contactLogRepository ?? throw new ArgumentNullException(nameof(contactLogRepository));
        }

        /// <inheritdoc />
        public async Task LogContact(User user, string description, string type)
        {
            var contactLog = new ContactLog()
            {
                UserId = user.Id,
                User = user,
                EventDescription = description,
                EventType = type
            };

            await _contactLogRepository.AddContactLog(contactLog);
        }
    }
}
