using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Services.ContactService;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserContacts([FromRoute] int contactId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{contactId}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserContact([FromRoute] int contactId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateUserContact([FromRoute] int contactId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{contactId}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUserContact([FromRoute] int contactId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{contactId}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteUserContact([FromRoute] int contactId)
        {
            throw new NotImplementedException();
        }
    }
}