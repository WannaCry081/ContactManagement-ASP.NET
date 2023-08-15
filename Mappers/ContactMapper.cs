using AutoMapper;
using backend.Entities;
using backend.Models.ContactModels;

namespace backend.Mappers
{
    /// <summary>
    /// Mapper class to define mappings between Contact entities and models.
    /// </summary>
    public class ContactMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactMapper"/> class.
        /// </summary>
        public ContactMapper()
        {
            // Map from Contact entity to GetUserContactModel
            CreateMap<Contact, GetUserContactModel>()
                .ReverseMap();

            // Map from Contact entity to UpsertUserContactModel and vice versa
            CreateMap<Contact, UpsertUserContactModel>()
                .ReverseMap();
        }
    }
}
