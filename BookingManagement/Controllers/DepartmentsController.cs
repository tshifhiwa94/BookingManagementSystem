using BookingManagement.Services.DepartmentsService;
using BookingManagement.Services.DepartmentsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(
            IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(CreateDepartmentDto input)
        {
            if (input == null)
            {
                return BadRequest("Input cannot be null");
            }
            var result = await _departmentService.CreateAsync(input);
            return Ok(result);
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }
            var result = await _departmentService.GetAsync(id);
            if (result == null)
            {
                return NotFound("Department not found");
            }
            return Ok(result);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _departmentService.GetAllAsync();
            return Ok(result);
        }
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(DepartmentDto input)
        {
            if (input == null || input.Id == Guid.Empty)
            {
                return BadRequest("Input cannot be null and must have a valid ID");
            }
            var result = await _departmentService.UpdateAsync(input);
            if (result == null)
            {
                return NotFound("Department not found for update");
            }
            return Ok(result);
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }
            var result = await _departmentService.DeleteAsync(id);
            if (!result)
            {
                return NotFound("Department not found for deletion");
            }
            return Ok("Department deleted successfully");
        }
    }
}
