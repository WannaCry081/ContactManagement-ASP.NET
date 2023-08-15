using AutoMapper;
using backend.Entities;
using backend.Models.UserModels;

namespace backend.Mappers
{
    /// <summary>
    /// Mapper class to define mappings between User entities and user-related models.
    /// </summary>
    public class UserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMapper"/> class.
        /// </summary>
        public UserMapper()
        {
            // Map from User entity to GetUserProfileModel and vice versa
            CreateMap<User, GetUserProfileModel>()
                .ReverseMap();

            // Map from User entity to UpdateUserProfileModel and vice versa
            CreateMap<User, UpdateUserProfileModel>()
                .ReverseMap();

            // Map from User entity to UpdateUserPasswordModel and vice versa
            CreateMap<User, UpdateUserPasswordModel>()
                .ReverseMap();
        }
    }
}
