using backend.Data;
using backend.Entities;

namespace backend.Repositories.ContactLogRepository
{
    /// <summary>
    /// 
    /// </summary> <summary>
    /// 
    /// </summary>
    public class ContactLogRepository : IContactLogRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
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