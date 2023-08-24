using AutoMapper;
using System.Security.Claims;
using backend.Entities;
using backend.Exceptions;
using backend.Repositories.UserRepository;
using backend.Models.UserModels;
using backend.Services.UserLogService;

namespace backend.Services.UserService
{
    /// <summary>
    /// Service class for user-related operations.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;
        private readonly IUserLogService _userLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        /// <param name="httpContext">The HttpContextAccessor to access the current HTTP context.</param>
        /// <param name="userRepository">The repository for user data access.</param>
        /// <param name="userLogService"></param>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameters is null.</exception>
        public UserService(IMapper mapper, IHttpContextAccessor httpContext, IUserRepository userRepository, IUserLogService userLogService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userLogService = userLogService ?? throw new ArgumentNullException(nameof(UserLogService));
        }

        /// <inheritdoc/>
        public async Task<User> GetUserByToken()
        {
            var httpContext = _httpContext.HttpContext;

            if (httpContext is null)
            {
                throw new TokenNotFoundException("Token not found.");
            }

            var user = await _userRepository.GetUserByToken(
                Convert.ToInt32(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                httpContext.User.FindFirstValue(ClaimTypes.Email)!
            );

            if (user is null)
            {
                throw new UserNotFoundException("User not found.");
            }

            return user;
        }

        /// <inheritdoc/>
        public async Task<GetUserProfileModel> GetUserProfile()
        {
            var response = await GetUserByToken();

            await _userLogService.LogUserAuthentication(
                response,
                $"User '{response.FirstName} {response.LastName}' with the Username '{response.UserName}' retrieve Successfully.",
                "Retrieve"
            );

            return _mapper.Map<GetUserProfileModel>(response);
        }

        /// <inheritdoc/>
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
            response.Email = user.Email;

            await _userLogService.LogUserAuthentication(
                _mapper.Map<User>(response),
                $"User '{response.FirstName} {response.LastName}' with the Username '{response.UserName}' retrieve Successfully.",
                "Update"
            );

            return response;
        }
    }
}