using AutoMapper;
using backend.Entities;
using backend.Models.AuthModels;

namespace backend.Mappers
{
    public class AuthMapper : Profile
    {
        public AuthMapper() {
            CreateMap<User, SignUpModel>()
                .ReverseMap();
            CreateMap<User, SignInModel>()
                .ReverseMap();
        }
    }
}