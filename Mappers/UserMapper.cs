using AutoMapper;
using backend.Entities;
using backend.Models.UserModels;

namespace backend.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, GetUserProfileModel>();
            CreateMap<User, UpdateUserProfileModel>();
            CreateMap<User, UpdateUserPasswordModel>();
            CreateMap<GetUserProfileModel, User>();
            CreateMap<UpdateUserProfileModel, User>();
            CreateMap<UpdateUserPasswordModel, User>();
        }
    }
}