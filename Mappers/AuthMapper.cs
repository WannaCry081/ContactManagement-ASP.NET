using AutoMapper;
using backend.Entities;
using backend.Models.AuthModels;

namespace backend.Mappers
{
    public class AuthMapper : Profile
    {
        public AuthMapper() {
            CreateMap<User, SignUpModel>();
            CreateMap<User, SignInModel>();
            CreateMap<SignUpModel, User>();
            CreateMap<SignInModel, User>();
        }
    }
}