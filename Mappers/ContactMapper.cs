using AutoMapper;
using backend.Entities;
using backend.Models.ContactModels;

namespace backend.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactMapper : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ContactMapper()
        {
            CreateMap<Contact, GetUserContactModel>()
                .ReverseMap();
            CreateMap<Contact, UpsertUserContactModel>()
                .ReverseMap();
        }
    }
}