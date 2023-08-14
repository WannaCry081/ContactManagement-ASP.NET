using Microsoft.AspNetCore.Mvc;
using backend.Exceptions;
using backend.Models.AuthModels;
using backend.Services.AuthService;

namespace backend.Controllers
{
    /// <summary>
    /// Controller for handling user authentication.
    /// </summary>
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="authService">The authentication service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Sign up a new user. 
        /// </summary>
        /// <param name="request">The sign-up request model</param>
        /// <returns>A jwt token.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/auth/signup
        ///     {
        ///         "firstName": "John",
        ///         "lastName" : "Doe",
        ///         "username" : "JohnDoe123",
        ///         "email" : "johndoe@example.com",
        ///         "password" : "password123",
        ///         "confirmPassword" : "password123"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully created an account.</response>
        /// <response code="400">Invalid contact details.</response>
        /// <response code="409">User already exists.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("signup")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel request)
        {
            try
            {
                var response = await _authService.SignUp(request);
                return Ok(response);
            }
            catch (UserSignUpFailedException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to add user to database.");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempting to sign up the user.");
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Sign in a user. 
        /// </summary>
        /// <param name="request">The sign-in request model.</param>
        /// <returns>A jwt token.</returns>
        /// <remarks>
        ///     
        ///     POST /api/auth/signin
        ///     {
        ///         "email" : "johndoe@example.com",
        ///         "password" : "password123"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Successfully log in user.</response>
        /// <response code="400">Invalid contact details.</response>
        /// <response code="401">Invalid user's password.</response>
        /// <response code="404">User does not exists.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignIn([FromBody] SignInModel request)
        {
            try
            {
                var response = await _authService.SignIn(request);
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get user.");
                return Unauthorized(ex.Message);
            }
            catch (UserSignInFailedException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to match Password.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempting to sign in the user.");
                return Problem(ex.Message);
            }
        }
    }
}