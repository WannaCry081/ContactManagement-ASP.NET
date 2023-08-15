using AutoMapper;
using backend.Entities;
using backend.Exceptions;
using backend.Models.AuthModels;
using backend.Repositories.AuthRepository;
using backend.Utils;

namespace backend.Services.AuthService
{
    /// <summary>
    /// Service class for authentication operations.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;

        /// <summary>
        /// Initializes a new instance of the `AuthService` class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="configuration">The configuration instance.</param>
        /// <param name="authRepository">The authentication repository.</param>
        /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null.</exception>
        public AuthService(IMapper mapper, IConfiguration configuration, IAuthRepository authRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        }

        /// <inheritdoc />
        public async Task<string> SignUp(SignUpModel request)
        {
            var newUser = _mapper.Map<User>(request);
            var isUserExists = await _authRepository.IsUserExists(newUser);
            if (isUserExists)
            {
                throw new UserExistsException("User already exists.");
            }

            HashPassword(newUser, request.Password);

            var isUserAdded = await _authRepository.AddNewUser(newUser);
            if (!isUserAdded)
            {
                throw new Exception("Failed to signup user.");
            }

            return TokenGenerator.AccessToken(newUser, _configuration);
        }

        /// <inheritdoc />
        public async Task<string> SignIn(SignInModel request)
        {
            var user = await _authRepository.GetUserByEmail(request.Email);
            if (user is null)
            {
                throw new UserNotFoundException("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Password does not match.");
            }

            return TokenGenerator.AccessToken(user, _configuration);
        }

        /// <summary>
        /// Hashes the user's password using bcrypt and updates the user object.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <param name="password">The user's password.</param>
        private void HashPassword(User user, string password)
        {
            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt);
        }
    }
}
