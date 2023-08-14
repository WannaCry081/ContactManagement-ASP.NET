using AutoMapper;
using System.Security.Claims;
using backend.Entities;
using backend.Exceptions;
using backend.Repositories.UserRepository;
using backend.Models.UserModels;

namespace backend.Services.UserService
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="httpContext"></param>
        /// <param name="userRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserService(IMapper mapper, IHttpContextAccessor httpContext, IUserRepository userRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(httpContext));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task<User> GetUserByToken()
        {
            var httpContext = _httpContext.HttpContext;

            if (httpContext is null)
            {
                throw new UserNotFoundException("Token not found.");
            }

            var user = await _userRepository.GetUserByToken(
                Convert.ToInt32(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                httpContext.User.FindFirstValue(ClaimTypes.Email)!
            );

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GetUserProfileModel> GetUserProfile()
        {
            var response = await GetUserByToken();
            return _mapper.Map<GetUserProfileModel>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetUserProfileModel> UpdateUserProfile(UpdateUserProfileModel request)
        {
            var user = await GetUserByToken();
            var newUserDetails = _mapper.Map<User>(request);
            var isUserUpdated = await _userRepository.UpdateUserProfile(user, newUserDetails);

            if (!isUserUpdated)
            {
                throw new Exception("Failed to update user profile.");
            }

            var response = _mapper.Map<GetUserProfileModel>(newUserDetails);
            response.Id = user.Id;
            
            return response;
        }
    }
}