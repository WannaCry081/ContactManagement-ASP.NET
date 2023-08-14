using AutoMapper;
using backend.Entities;
using backend.Exceptions;
using backend.Models.AuthModels;
using backend.Repositories.AuthRepository;
using backend.Utils;

namespace backend.Services.AuthService
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="configuration"></param>
        /// <param name="authRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AuthService(IMapper mapper, IConfiguration configuration, IAuthRepository authRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="UserSignUpFailedException"></exception>
        public async Task<string> SignUp(SignUpModel request)
        {
            var newUser = _mapper.Map<User>(request);
            var isUserExists = await _authRepository.IsUserExists(newUser);
            if (isUserExists)
            {
                throw new UserSignUpFailedException("User already exists.");
            }

            HashPasword(newUser, request.Password);

            var isUserAdded = await _authRepository.AddNewUser(newUser);
            if (!isUserAdded)
            {
                throw new UserSignUpFailedException("Failed to signup user.");
            }

            return TokenGenerator.AccessToken(newUser, _configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="UserSignInFailedException"></exception>
        public async Task<string> SignIn(SignInModel request)
        {
            var user = await _authRepository.GetUserByEmail(request.Email);
            if (user is null)
            {
                throw new UserNotFoundException("user not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new UserSignInFailedException("Password does not match.");
            }

            return TokenGenerator.AccessToken(user, _configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        private void HashPasword(User user, string password)
        {
            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt);
        }
    }
}