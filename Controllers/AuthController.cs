using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{   
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        public AuthController() {

        }

        [HttpPost("/signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> SignUp() {
            return Ok("Sign up");
        }

        [HttpPost("/signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> SignIn() {
            return Ok("Sign in");
        }
    }
}