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
        private readonly IServiceRequestService _serviceRequestService;
        public ServicesController(
            IServiceService serviceService, IServiceRequestService serviceRequestService)
        {
            _serviceService = serviceService;
            _serviceRequestService = serviceRequestService;
        }
        #region Service

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
        #endregion

        #region Service Request
        [HttpPost("ServiceRequestCreateAsync")]
        public async Task<IActionResult> ServiceRequestCreateAsync(CreateServiceRequestDto input)
        {
            if (input is null) return BadRequest("Payload should not be empty");

            var serviceRequest = await _serviceRequestService.CreateAsync(input);

            if (serviceRequest is null) return NotFound("RequesterId or ServiceId does not exist or both.");
            return Ok(serviceRequest);
        }

        [HttpGet("ServiceRequestGetAsync")]
        public async Task<IActionResult> ServiceRequestGetAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid service request ID.");
            var result = await _serviceRequestService.GetAsync(id);
            if (result == null) return NotFound("Service request not found.");
            return Ok(result);
        }

        [HttpGet("ServiceRequestGetAllAsync")]
        public async Task<IActionResult> ServiceRequestGetAllAsync()
        {
            var result = await _serviceRequestService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("ServiceRequestUpdateAsync")]
        public async Task<IActionResult> ServiceRequestUpdateAsync(UpdateServiceRequestDto input)
        {
            if (input == null || input.Id == Guid.Empty) return BadRequest("Invalid service request data.");
            var result = await _serviceRequestService.UpdateAsync(input);
            if (result == null) return NotFound("Service request not found.");
            return Ok(result);
        }

        [HttpDelete("ServiceRequestDeleteAsync")]
        public IActionResult DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid service request ID.");
            var result = _serviceRequestService.DeleteAsync(id);
            if (!result.Result) return NotFound("Service request not found.");
            return Ok("Service request deleted successfully.");
        }

        #endregion

    }
}
