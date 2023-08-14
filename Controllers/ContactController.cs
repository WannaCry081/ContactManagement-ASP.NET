using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Exceptions;
using backend.Services.ContactService;
using backend.Services.UserService;
using Microsoft.AspNetCore.Http.HttpResults;
using backend.Models.ContactModels;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;
        private readonly IUserService _userService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserContacts()
        {
            try
            {
                var user = await _userService.GetUserProfile();
                var response = await _contactService.GetUserContacts(user);
                return Ok(response);
            }
            catch (NotFoundException ex)
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

        [HttpGet("{contactId}")]
        [Produces("application/json")]
        public Task<IActionResult> GetUserContact([FromRoute] int contactId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public Task<IActionResult> CreateUserContact([FromBody] UpsertUserContactModel request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{contactId}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public Task<IActionResult> UpdateUserContact([FromRoute] int contactId, [FromBody] UpsertUserContactModel request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{contactId}")]
        [Produces("application/json")]
        public Task<IActionResult> DeleteUserContact([FromRoute] int contactId)
        {
            throw new NotImplementedException();
        }
    }
}