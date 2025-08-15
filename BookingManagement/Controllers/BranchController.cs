using BookingManagement.Services.BranchService;
using BookingManagement.Services.BranchService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(CreateBranchDto input)
        {
            if (input is null)
            {
                return BadRequest("Input cannot be null");
            }
            var result = await _branchService.CreateAsync(input);
            return Ok(result);
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }
            var result = await _branchService.GetAsync(id);
            if (result is null)
            {
                return NotFound("Branch not found");
            }
            return Ok(result);
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _branchService.GetAllAsync();
            return Ok(result);
        }
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateBranchDto input)
        {
            if (input is null || input.Id == Guid.Empty)
            {
                return BadRequest("Invalid input or ID");
            }
            var result = await _branchService.UpdateAsync(input);
            if (result is null)
            {
                return NotFound("Could not find the Branch, Manager, Address, or any of them.");
            }
            return Ok(result);
        }
    }
}
