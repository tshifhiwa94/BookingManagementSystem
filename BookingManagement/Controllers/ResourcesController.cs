using BookingManagement.Services.ResourcesService;
using BookingManagement.Services.ResourcesService.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        public ResourcesController(
           IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(CreateResourceDto input)
        {
            if (input is null) return BadRequest("Input cannot be null.");
            var result = await _resourceService.CreateAsync(input);
            if (result is null) return NotFound("Branch or Department not found.");
            return Ok(result);
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid resource ID.");
            var result = await _resourceService.GetAsync(id);
            if (result is null) return NotFound("Resource not found.");
            return Ok(result);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _resourceService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateResourceDto input)
        {
            if (input is null) return BadRequest("Input cannot be null.");
            var result = await _resourceService.UpdateAsync(input);
            if (result is null) return NotFound("Resource not found.");
            return Ok(result);
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid resource ID.");
            var result = await _resourceService.DeleteAsync(id);
            if (!result) return NotFound("Resource not found Or Failed to Delete.");
            return Ok("Resource deleted successfully.");
        }
    }
}
