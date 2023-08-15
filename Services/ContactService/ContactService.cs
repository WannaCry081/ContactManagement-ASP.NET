using AutoMapper;
using backend.Entities;
using backend.Exceptions;
using backend.Models.ContactModels;
using backend.Repositories.ContactRepository;

namespace backend.Services.ContactService
{
    /// <summary>
    /// Service for contact operations.
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="contactRepository">The contact repository.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
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

            return response;
        }
    }
}