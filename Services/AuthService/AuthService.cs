using AutoMapper;
using backend.Entities;
using backend.Exceptions;
using backend.Models.AuthModels;
using backend.Repositories.AuthRepository;
using backend.Utils;

namespace backend.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;

        public AuthService(IMapper mapper, IConfiguration configuration, IAuthRepository authRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        }

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

        public Task<string> SignIn(SignInModel request)
        {
            throw new NotImplementedException();
        }

        private void HashPasword(User user, string password)
        {
            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt);
        }
    }
}