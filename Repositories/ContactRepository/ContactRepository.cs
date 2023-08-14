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

        public async Task<Contact?> GetUserContact(int userId, int contactId)
        {
            return await _context.Contacts.Where(
                (c) => c.UserId.Equals(userId) &&
                        c.Id.Equals(contactId)
            ).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateUserContact(Contact contact)
        {
            _context.Add(contact);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateUserContact(Contact contact, Contact newContactDetails)
        {
            contact.FirstName = newContactDetails.FirstName;
            contact.LastName = newContactDetails.LastName;
            contact.Email = newContactDetails.Email;
            contact.PhoneNo = newContactDetails.PhoneNo;
            contact.Address = newContactDetails.Address;
            contact.UpdatedAt = DateTime.Now;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteUserContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}