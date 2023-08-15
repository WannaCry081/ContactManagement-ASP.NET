using backend.Entities;
using backend.Models.ContactModels;

namespace backend.Services.ContactService
{
    /// <summary>
    /// Service interface for contact-related operations.
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// Retrieves the list of contacts associated with the specified user.
        /// </summary>
        /// <param name="user">The user for whom to retrieve contacts.</param>
        /// <returns>A collection of <see cref="GetUserContactModel"/> representing user contacts.</returns>
        Task<ICollection<GetUserContactModel>> GetUserContacts(User user);

        /// <summary>
        /// Retrieves a specific contact associated with the specified user.
        /// </summary>
        /// <param name="user">The user for whom to retrieve the contact.</param>
        /// <param name="contactId">The ID of the contact to retrieve.</param>
        /// <returns>The <see cref="GetUserContactModel"/> representing the requested contact.</returns>
        Task<GetUserContactModel> GetUserContact(User user, int contactId);

        /// <summary>
        /// Creates a new contact for the specified user.
        /// </summary>
        /// <param name="user">The user for whom to create the contact.</param>
        /// <param name="request">The details of the new contact.</param>
        /// <returns>The <see cref="GetUserContactModel"/> representing the newly created contact.</returns>
        Task<GetUserContactModel> CreateUserContact(User user, UpsertUserContactModel request);

        /// <summary>
        /// Updates an existing contact associated with the specified user.
        /// </summary>
        /// <param name="user">The user for whom to update the contact.</param>
        /// <param name="contactId">The ID of the contact to update.</param>
        /// <param name="request">The updated details of the contact.</param>
        /// <returns>The <see cref="GetUserContactModel"/> representing the updated contact.</returns>
        Task<GetUserContactModel> UpdateUserContact(User user, int contactId, UpsertUserContactModel request);
        
        /// <summary>
        /// Deletes a contact associated with the specified user.
        /// </summary>
        /// <param name="user">The user for whom to delete the contact.</param>
        /// <param name="contactId">The ID of the contact to delete.</param>
        /// <returns><c>true</c> if the contact is successfully deleted; otherwise, <c>false</c>.</returns>
        Task<bool> DeleteUserContact(User user, int contactId);
    }
}
