using AutoMapper;
using System.Security.Claims;
using backend.Entities;
using backend.Exceptions;
using backend.Repositories.UserRepository;
using backend.Models.UserModels;

namespace backend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IHttpContextAccessor httpContext, IUserRepository userRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(httpContext));
        }

        public async Task<User> GetUserProfile()
        {
            var httpContext = _httpContext.HttpContext;

            if (httpContext is null)
            {
                throw new NotFoundException("Token not found.");
            }

            var user = await _userRepository.GetUserByToken(
                Convert.ToInt32(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                httpContext.User.FindFirstValue(ClaimTypes.Email)!
            );

            if (user is null)
            {
                throw new NotFoundException("User not found");
            }

            return user;
        }
    }
}