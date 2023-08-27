using AutoMapper;
using backend.Entities;
using backend.Exceptions;
using backend.Models.ContactModels;
using backend.Repositories.ContactRepository;
using backend.Services.ContactLogService;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Services.ContactService
{
    /// <summary>
    /// Service for contact operations.
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly IContactLogService _contactLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="contactRepository">The contact repository.</param>
        /// <param name="contactLogService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContactService(IMapper mapper, IContactRepository contactRepository, IContactLogService contactLogService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _contactLogService = contactLogService ?? throw new ArgumentNullException(nameof(contactLogService));
        }

        /// <inheritdoc/>
        public async Task<ICollection<GetUserContactModel>> GetUserContacts(User user)
        {
            var response = await _contactRepository.GetUserContacts(user.Id);
            return _mapper.Map<ICollection<GetUserContactModel>>(response);
        }

        /// <inheritdoc/>
        public async Task<GetUserContactModel> GetUserContact(User user, int contactId)
        {
            var response = await _contactRepository.GetUserContact(user.Id, contactId);
            if (response is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            // Records audit log for geting user's contact information
            await _contactLogService.LogContact(
                user,
                $"User '{user.FirstName} {user.LastName}' Successfully Retrieve a Contact.",
                "Retrieve"
            );

            return _mapper.Map<GetUserContactModel>(response);
        }

        /// <inheritdoc/>
        public async Task<GetUserContactModel> CreateUserContact(User user, UpsertUserContactModel request)
        {
            var newContact = _mapper.Map<Contact>(request);
            newContact.UserId = user.Id;

            var response = await _contactRepository.CreateUserContact(newContact);
            if (!response)
            {
                throw new Exception("Failed to add contact.");
            }

            // Records audit log for creating new user's contact
            await _contactLogService.LogContact(
                user,
                $"User '{user.FirstName} {user.LastName}' Successfully Created a Contact.",
                "Create"
            );

            return _mapper.Map<GetUserContactModel>(newContact);
        }

        /// <inheritdoc/>
        public async Task<GetUserContactModel> UpdateUserContact(User user, int contactId, UpsertUserContactModel request)
        {
            var contact = await _contactRepository.GetUserContact(user.Id, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            var newContactDetails = _mapper.Map<Contact>(request);
            var isContactUpdated = await _contactRepository.UpdateUserContact(contact, newContactDetails);
            if (!isContactUpdated)
            {
                throw new Exception("Failed to update contact.");
            }

            var response = _mapper.Map<GetUserContactModel>(newContactDetails);
            response.Id = contact.Id;

            // Records audit log for updating user's contact information
            await _contactLogService.LogContact(
                user,
                $"User '{user.FirstName} {user.LastName}' Successfully Update a Contact.",
                "Update"
            );

            return response;
        }

        /// <inheritdoc />
        public async Task<bool> UpdateUserContactProperty(User user, int contactId, JsonPatchDocument<Contact> request)
        {
            var contact = await _contactRepository.GetUserContact(user.Id, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            var response = await _contactRepository.UpdateUserContactProperty(contact, request);
            if (!response)
            {
                throw new Exception("Failed to update contact.");
            }
            return response;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteUserContact(User user, int contactId)
        {
            var contact = await _contactRepository.GetUserContact(user.Id, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            var response = await _contactRepository.DeleteUserContact(contact);
            if (!response)
            {
                throw new Exception("Failed to delete contact.");
            }

            // Records audit log for deleting user's contact information
            await _contactLogService.LogContact(
                user,
                $"User '{user.FirstName} {user.LastName}' Successfully Delete a Contact.",
                "Delete"
            );

            return response;
        }
    }
}