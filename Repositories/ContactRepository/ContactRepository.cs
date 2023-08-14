using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Entities;

namespace backend.Repositories.ContactRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContactRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ICollection<Contact>> GetUserContacts(int userId)
        {
            return await _context.Contacts.Where(
                (c) => c.UserId.Equals(userId)
            ).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<Contact?> GetUserContact(int userId, int contactId)
        {
            return await _context.Contacts.Where(
                (c) => c.UserId.Equals(userId) &&
                        c.Id.Equals(contactId)
            ).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task<bool> CreateUserContact(Contact contact)
        {
            _context.Add(contact);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="newContactDetails"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}