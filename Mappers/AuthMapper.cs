using AutoMapper;
using backend.Entities;
using backend.Models.AuthModels;

namespace backend.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthMapper : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AuthMapper() {
            CreateMap<User, SignUpModel>()
                .ReverseMap();
            CreateMap<User, SignInModel>()
                .ReverseMap();
        }
    }
}