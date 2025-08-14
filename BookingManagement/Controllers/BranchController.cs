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
            if (input == null)
            {
                return BadRequest("Input cannot be null");
            }
            var result = await _branchService.CreateAsync(input);
            return Ok(result);
        }
    }
}
