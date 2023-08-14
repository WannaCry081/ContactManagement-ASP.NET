using AutoMapper;
using backend.Entities;
using backend.Exceptions;
using backend.Models.ContactModels;
using backend.Repositories.ContactRepository;

namespace backend.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public async Task<ICollection<GetUserContactModel>> GetUserContacts(User user)
        {
            var response = await _contactRepository.GetUserContacts(user.Id);
            return _mapper.Map<ICollection<GetUserContactModel>>(response);
        }

        public async Task<GetUserContactModel> GetUserContact(User user, int contactId)
        {
            var response = await _contactRepository.GetUserContact(user.Id, contactId);
            if (response is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }
            return _mapper.Map<GetUserContactModel>(response);
        }

        public async Task<GetUserContactModel> CreateUserContact(User user, UpsertUserContactModel request)
        {
            var newContact = _mapper.Map<Contact>(request);
            newContact.UserId = user.Id;

            var response = await _contactRepository.CreateUserContact(newContact);
            if (!response)
            {
                throw new ContactAddFailedException("Failed to add contact.");
            }
            return _mapper.Map<GetUserContactModel>(newContact);
        }

        public async Task<GetUserContactModel> UpdateUserContact(User user, int contactId, UpsertUserContactModel request)
        {
            var contact = await _contactRepository.GetUserContact(user.Id, contactId);
            if (contact is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }

            var newContactDetails = _mapper.Map<Contact>(request);
            var response = await _contactRepository.UpdateUserContact(contact, newContactDetails);
            if (!response)
            {
                throw new ContactUpdateFailedException("Failed to update contact.");
            }
            
            return _mapper.Map<GetUserContactModel>(newContactDetails);
        }

        public Task<bool> DeleteUserContact(User user, int contactId)
        {
            throw new NotImplementedException();
        }
    }
}