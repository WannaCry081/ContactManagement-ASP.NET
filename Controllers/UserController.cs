using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Models.UserModels;
using backend.Services.UserService;
using backend.Exceptions;

namespace backend.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var response = await _userService.GetUserProfile();
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get user information.");
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempting to get the user profile.");
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileModel request)
        {
            try
            {
                var response = await _userService.UpdateUserProfile(request);
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get user.");
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempting to update the user profile.");
                return Problem(ex.Message);
            }
        }
    }
}