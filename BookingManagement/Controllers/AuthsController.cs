using BookingManagement.Services.AuthService;
using BookingManagement.Services.AuthService.Dtos;
using BookingManagement.Services.PersonService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreatePersonDto personDto)
        {
            if (personDto == null) { return BadRequest("Payload is empty"); }

            var newPerson = await _authService.RegisterAsync(personDto);

            if (newPerson == null) { return BadRequest("Username or Email Address already exist or failed to create user"); }

            return Ok(newPerson);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto input)
        {
            if (string.IsNullOrEmpty(input.Username) || string.IsNullOrEmpty(input.Password))
            {
                return BadRequest("Missing credentials: please provide both username and password.");
            }

            var user = await _authService.LoginAsync(input);
            if (user == null)
            {
                return BadRequest("Login Failed");
            }

            return Ok(user);
        }

        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto request)
        {
            if (request == null) return BadRequest(" request should not be empty");

            return Ok(await _authService.RefreshTokenAsync(request));
        }
    }
}
