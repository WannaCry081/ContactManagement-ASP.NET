using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Exceptions;
using backend.Services.ContactService;
using backend.Services.UserService;
using backend.Models.ContactModels;

namespace backend.Controllers
{
    /// <summary>
    /// Controller for handling User's Contact Information
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("/api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="contactService">The contact service.</param>
        /// <param name="userService">The user service.</param> 
        /// <exception cref="ArgumentNullException"></exception>
        public ContactController(ILogger<ContactController> logger, IContactService contactService, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Get user's contact list.
        /// </summary>
        /// <returns>A list of user's contacts.</returns>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /api/contact
        /// 
        /// </remarks>
        /// <response code="200">Successfully returns list of user's contacts.</response>
        /// <response code="403">Invalid jwt token.</response>
        /// <response code="404">User not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<GetUserContactModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserContacts()
        {
            try
            {
                // To decrypt jwt token and returns the user
                var user = await _userService.GetUserByToken();

                var response = await _contactService.GetUserContacts(user);
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
                _logger.LogCritical(ex, "An error occurred while attempting to get the user's contacts.");
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get user's specific contact information.
        /// </summary>
        /// <param name="contactId">The ID of the specific contact.</param>
        /// <returns>A response containing user's contact information.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/contact/1
        ///     
        /// </remarks>
        /// <response code="200">Returns the user's contact information.</response>
        /// <response code="403">Invalid jwt token.</response>
        /// <response code="404">User and Contact with the specified ID not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{contactId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetUserContactModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserContact([FromRoute] int contactId)
        {
            try
            {
                // To decrypt jwt token and returns the user
                var user = await _userService.GetUserByToken();

                var response = await _contactService.GetUserContact(user, contactId);
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
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting  to retrieve the user's contact information.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get user's contact.");
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Create new user's contact information.
        /// </summary>
        /// <param name="request">The contact details to be created.</param>
        /// <returns>The newly created user's contact.</returns>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     POST /api/contact 
        ///     {
        ///         "firstName" : "John", 
        ///         "lastName" : "Doe", 
        ///         "email" : "johndoe@example.com",
        ///         "phoneNo" : "09123456789",
        ///         "address" : "USA"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Returns the new user's contact.</response>
        /// <response code="403">Invalid jwt token.</response>
        /// <response code="404">User not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetUserContactModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUserContact([FromBody] UpsertUserContactModel request)
        {
            try
            {
                // To decrypt jwt token and returns the user
                var user = await _userService.GetUserByToken();

                var response = await _contactService.CreateUserContact(user, request);
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
                _logger.LogCritical(ex, "An error occurred while attempting to create the user's contact.");
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates user's contact information.
        /// </summary>
        /// <param name="contactId">The ID of the specific contact.</param>
        /// <param name="request">The contact details to be updated.</param>
        /// <returns>The updated user's contact.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/contact/1
        ///     {
        ///         "firstName" : "John", 
        ///         "lastName" : "Doe", 
        ///         "email" : "johndoe@example.com",
        ///         "phoneNo" : "09123456789",
        ///         "address" : "USA"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Returns the new user's contact information.</response>
        /// <response code="403">Invalid jwt token.</response>
        /// <response code="404">Contact with the specified ID not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{contactId}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetUserContactModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserContact([FromRoute] int contactId, [FromBody] UpsertUserContactModel request)
        {
            try
            {
                // To decrypt jwt token and returns the user
                var user = await _userService.GetUserByToken();

                var response = await _contactService.UpdateUserContact(user, contactId, request);
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
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get user.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while attempting to update the user's contact.");
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes user's contact information.
        /// </summary>
        /// <param name="contactId">The ID of the specific contact.</param>
        /// <returns>Returns a success message.</returns>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     DELETE /api/contact/1
        ///     
        /// </remarks>
        /// <response code="200">User's contact successfully deleted.</response>
        /// <response code="403">Invalid jwt token.</response>
        /// <response code="404">Contact with the specified ID not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{contactId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetUserContactModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserContact([FromRoute] int contactId)
        {
            try
            {
                // To decrypt jwt token and returns the user
                var user = await _userService.GetUserByToken();

                var response = await _contactService.DeleteUserContact(user, contactId);
                return Ok("Successfully delete user's contact.");
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
            catch (ContactNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to get user.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while attenpting to delete user's contact.");
                return Problem(ex.Message);
            }
        }
    }
}