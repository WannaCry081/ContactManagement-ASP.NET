using backend.Data;
using backend.Entities;

namespace backend.Repositories.ContactLogRepository
{
    /// <summary>
    /// Repository class for managing contact log data.
    /// </summary>
    public class ContactLogRepository : IContactLogRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactLogRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is null.</exception>
        public ContactLogRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task AddContactLog(ContactLog contactLog)
        {
            _context.ContactLogs.Add(contactLog);
            await _context.SaveChangesAsync();
        }
    }
}
