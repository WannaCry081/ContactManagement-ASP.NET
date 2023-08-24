using backend.Entities;
using backend.Entities.Types;
using backend.Repositories.ContactLogRepository;

namespace backend.Services.ContactLogService
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactLogService : IContactLogService
    {
        private readonly IContactLogRepository _contactLogRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactLogRepository"></param>
        public ContactLogService(IContactLogRepository contactLogRepository)
        {
            _contactLogRepository = contactLogRepository ?? throw new ArgumentNullException(nameof(contactLogRepository));
        }

        /// <inheritdoc/> 
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