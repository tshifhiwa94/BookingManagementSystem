using BookingManagement.Services.ServicesService;
using BookingManagement.Services.ServicesService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServicesController(
            IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(CreateServiceDto input)
        {
            if (input == null) return BadRequest("Invalid service data.");
            var result = await _serviceService.CreateAsync(input);
            if (result == null) return NotFound("Department not found.");
            return Ok(result);
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid service ID.");
            var result = await _serviceService.GetAsync(id);
            if (result == null) return NotFound("Service not found.");
            return Ok(result);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _serviceService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateServiceDto input)
        {
            if (input == null || input.Id == Guid.Empty) return BadRequest("Invalid service data.");
            var result = await _serviceService.UpdateAsync(input);
            if (result == null) return NotFound("Service not found.");
            return Ok(result);
        }
    }
}
