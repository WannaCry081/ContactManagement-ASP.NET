using Microsoft.AspNetCore.Mvc;
using backend.Exceptions;
using backend.Models.AuthModels;
using backend.Services.AuthService;
using System.Linq.Expressions;

namespace backend.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("/signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
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
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempting to sign up the user.");
                return Problem(ex.Message);
            }
        }

        [HttpPost("/signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel request)
        {
            try
            {
                var response = await _authService.SignIn(request);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "An error occurred while attempting to sign in a user.");
                return NotFound(ex.Message);
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