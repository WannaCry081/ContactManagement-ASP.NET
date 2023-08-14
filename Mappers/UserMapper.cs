using AutoMapper;
using backend.Entities;
using backend.Models.UserModels;

namespace backend.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserMapper : Profile
    {
        /// <summary>
        /// 
        /// </summary>
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