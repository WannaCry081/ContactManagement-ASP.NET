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

        public Task<GetUserContactModel> CreateUserContact(User user, UpsertUserContactModel request)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserContactModel> UpdateUserContact(User user, UpsertUserContactModel request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserContact(User user, int contactId)
        {
            throw new NotImplementedException();
        }
    }
}