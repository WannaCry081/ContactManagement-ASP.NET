using backend.Entities;
using backend.Entities.Types;
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
        public async Task LogContact(User user, Contact contact, string description, ContactEventType type)
        {
            var contactLog = new ContactLog()
            {
                UserId = user.Id,
                User = user,
                ContactId = contact.Id,
                Contact = contact,
                EventDescription = description,
                EventType = type
            };

            await _contactLogRepository.AddContactLog(contactLog);
        }
    }
}
