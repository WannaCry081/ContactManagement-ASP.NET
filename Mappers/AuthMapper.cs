using AutoMapper;
using backend.Entities;
using backend.Models.AuthModels;

namespace backend.Mappers
{
    /// <summary>
    /// Mapper class to define mappings between User entities and authentication models.
    /// </summary>
    public class AuthMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthMapper"/> class.
        /// </summary>
        public AuthMapper() {
            // Map from User entity to SignUpModel and vice versa
            CreateMap<User, SignUpModel>()
                .ReverseMap();

            // Map from User entity to SignInModel and vice versa
            CreateMap<User, SignInModel>()
                .ReverseMap();
        }
    }
}
