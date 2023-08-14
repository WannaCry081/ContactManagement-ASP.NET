using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;

namespace backend.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Contact>> GetUserContacts(int userId)
        {
            return await _context.Contacts.Where(
                (c) => c.UserId.Equals(userId)
            ).ToListAsync();
        }
    }
}