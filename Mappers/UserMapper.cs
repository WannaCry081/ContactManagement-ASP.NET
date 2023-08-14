using AutoMapper;
using backend.Entities;
using backend.Models.UserModels;

namespace backend.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, GetUserProfileModel>()
                .ReverseMap();
            CreateMap<User, UpdateUserProfileModel>()
                .ReverseMap();
            CreateMap<User, UpdateUserPasswordModel>()
                .ReverseMap();
        }
    }
}