using Microsoft.AspNetCore.JsonPatch;
using backend.Entities;

namespace backend.Repositories.ContactRepository
{
    /// <summary>
    /// Interface for user contact repository.
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// Get contacts of a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Returns a collection of user contacts.</returns>
        Task<ICollection<Contact>> GetUserContacts(int userId);

        /// <summary>
        /// Get a user contact by its ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="contactId">The ID of the contact.</param>
        /// <returns>Returns the user contact with the specified ID, or null if not found.</returns>
        Task<Contact?> GetUserContact(int userId, int contactId);

        /// <summary>
        /// Create a new user contact.
        /// </summary>
        /// <param name="contact">The contact to create.</param>
        /// <returns>Returns true if the contact was created successfully.</returns>
        Task<bool> CreateUserContact(Contact contact);

        /// <summary>
        /// Update a user contact with new details.
        /// </summary>
        /// <param name="contact">The existing contact.</param>
        /// <param name="newContactDetails">The new contact details.</param>
        /// <returns>Returns true if the contact was updated successfully.</returns>
        Task<bool> UpdateUserContact(Contact contact, Contact newContactDetails);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> UpdateUserContactProperty(Contact contact, JsonPatchDocument<Contact> request);

        /// <summary>
        /// Delete a user contact.
        /// </summary>
        /// <param name="contact">The contact to delete.</param>
        /// <returns>Returns true if the contact was deleted successfully.</returns>
        Task<bool> DeleteUserContact(Contact contact);
    }
}
