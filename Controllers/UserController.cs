using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Models.UserModels;
using backend.Services.UserService;
using backend.Exceptions;

namespace backend.Controllers
{
    /// <summary>
    /// Controller for handling User's Profile
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> 
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="userService">The user service.</param> 
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Get user's profile.
        /// </summary>
        /// <returns>The user's profile.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/user  
        ///      
        /// </remarks>
        /// <response code="200">Returns the user's profile.</response>
        /// <response code="403">Invalid jwt token.</response>
        /// <response code="404">User not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetUserProfileModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var response = await _userService.GetUserProfile();
                return Ok(response);
            }
            catch (TokenNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get access token.");
                return Forbid(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get user information.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempting to get the user profile.");
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Update user's profile.
        /// </summary>
        /// <param name="request">The new user's profile details to be updated.</param>
        /// <returns>The new updated user's profile.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/user
        ///     {
        ///         "firstName" : "John",
        ///         "lastName" : "Doe",
        ///         "userName" : "JohnDoe123"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Returns the updated user's profile.</response>
        /// <response code="403">Invalid jwt token.</response>
        /// <response code="404">User not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetUserProfileModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileModel request)
        {
            try
            {
                var response = await _userService.UpdateUserProfile(request);
                return Ok(response);
            }
            catch (TokenNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get access token.");
                return Forbid(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get user.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempting to update the user profile.");
                return Problem(ex.Message);
            }
        }
    }
}