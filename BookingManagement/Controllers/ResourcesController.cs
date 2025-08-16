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
        private readonly IResourceRequestService _resourceRequestService;
        public ResourcesController(
           IResourceService resourceService
         , IResourceRequestService resourceRequestService)
        {
            _resourceService = resourceService;
            _resourceRequestService = resourceRequestService;
        }

        #region Resource Endpints


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

        #endregion

        #region Resource Requests Endpints

        [HttpPost("CreateResourceRequestAsync")]
        public async Task<IActionResult> CreateResourceRequestAsync(CreateResourceRequestDto input)
        {
            if (input is null) return BadRequest("Input cannot be null.");
            var result = await _resourceRequestService.CreateAsync(input);
            if (result is null) return NotFound("Resource or Requester not found.");
            return Ok(result);
        }

        [HttpGet("GetResourceRequestAsync")]
        public async Task<IActionResult> GetResourceRequestAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid resource request ID.");
            var result = await _resourceRequestService.GetAsync(id);
            if (result is null) return NotFound("Resource request not found.");
            return Ok(result);
        }

        [HttpGet("GetAllResourceRequestsAsync")]
        public async Task<IActionResult> GetAllResourceRequestsAsync()
        {
            var result = await _resourceRequestService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("UpdateResourceRequestAsync")]
        public async Task<IActionResult> UpdateResourceRequestAsync(UpdateResourceRequestDto input)
        {
            if (input is null) return BadRequest("Input cannot be null.");
            var result = await _resourceRequestService.UpdateAsync(input);
            if (result is null) return NotFound("Resource request not found.");
            return Ok(result);
        }

        [HttpDelete("DeleteResourceRequestAsync")]
        public async Task<IActionResult> DeleteResourceRequestAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid resource request ID.");
            var result = await _resourceRequestService.DeleteAsync(id);
            if (!result) return NotFound("Resource request not found Or Failed to Delete.");
            return Ok("Resource request deleted successfully.");
        }


        #endregion
    }
}
