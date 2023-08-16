using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;

namespace backend.Repositories.ContactRepository
{
    /// <summary>
    /// Repository class for contact operations.
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the `ContactRepository` class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <exception cref="ArgumentNullException">Thrown if the context is null.</exception>
        public ContactRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<ICollection<Contact>> GetUserContacts(int userId)
        {
            return await _context.Contacts.Where(
                (c) => c.UserId.Equals(userId)
            ).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Contact?> GetUserContact(int userId, int contactId)
        {
            return await _context.Contacts.Where(
                (c) => c.UserId.Equals(userId) &&
                        c.Id.Equals(contactId)
            ).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> CreateUserContact(Contact contact)
        {
            _context.Add(contact);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateUserContact(Contact contact, Contact newContactDetails)
        {
            contact.FirstName = newContactDetails.FirstName;
            contact.LastName = newContactDetails.LastName;
            contact.Email = newContactDetails.Email;
            contact.PhoneNo = newContactDetails.PhoneNo;
            contact.BillingAddress = newContactDetails.BillingAddress;
            contact.DeliveryAddress = newContactDetails.DeliveryAddress;
            contact.UpdatedAt = DateTime.Now;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteUserContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}