using AutoMapper;
using backend.Entities;
using backend.Exceptions;
using backend.Models.ContactModels;
using backend.Repositories.ContactRepository;

namespace backend.Services.ContactService
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="contactRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ICollection<GetUserContactModel>> GetUserContacts(User user)
        {
            var response = await _contactRepository.GetUserContacts(user.Id);
            return _mapper.Map<ICollection<GetUserContactModel>>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        /// <exception cref="ContactNotFoundException"></exception>
        public async Task<GetUserContactModel> GetUserContact(User user, int contactId)
        {
            var response = await _contactRepository.GetUserContact(user.Id, contactId);
            if (response is null)
            {
                throw new ContactNotFoundException("Contact not found.");
            }
            return _mapper.Map<GetUserContactModel>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="contactId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ContactNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        /// <exception cref="ContactNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
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