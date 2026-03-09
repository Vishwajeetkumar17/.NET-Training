using LoginAndRoleBasedAccess.Models.DTOs;
using LoginAndRoleBasedAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginAndRoleBasedAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authService.SignupAsync(request);

            if (response == null)
            {
                return BadRequest(new { message = "Username or email already exists" });
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authService.LoginAsync(request);

            if (response == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return Ok(response);
        }
    }
}
