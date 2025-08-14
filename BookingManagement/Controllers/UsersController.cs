using BookingManagement.Services.UserService;
using BookingManagement.Services.UserService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User DTO cannot be null");
            }
            var createdUser = await _userService.CreateAsync(userDto);
            return Ok(createdUser);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetAsync(id.ToString());
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User DTO cannot be null");
            }
            var updatedUser = await _userService.UpdateAsync(id.ToString(), userDto);
            if (updatedUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(updatedUser);
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }

            var result = await _userService.DeleteAsync(id.ToString());
            if (!result)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return NoContent(); // 204 No Content
        }
    }
}
