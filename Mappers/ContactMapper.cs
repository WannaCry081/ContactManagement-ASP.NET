using AutoMapper;
using backend.Entities;
using backend.Models.ContactModels;

namespace backend.Mappers
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, GetUserContactModel>();
            CreateMap<Contact, UpsertUserContactModel>();
            CreateMap<GetUserContactModel, Contact>();
            CreateMap<UpsertUserContactModel, Contact>();
        }
    }
}