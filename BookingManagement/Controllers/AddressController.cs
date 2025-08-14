using BookingManagement.Services.AddressService;
using BookingManagement.Services.AddressService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var address = await _addressService.GetAsync(id);
            return Ok(address);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var addresses = await _addressService.GetAllAsync();
            return Ok(addresses);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(AddressDto addressDto)
        {
            if (addressDto == null)
            {
                return BadRequest("Address data is required.");
            }
            var createdAddress = await _addressService.CreateAsync(addressDto);
            return Ok(createdAddress);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAddressDto addressDto)
        {

            if (addressDto == null)
            {
                return BadRequest("Address data is required.");
            }
            try
            {
                var updatedAddress = await _addressService.UpdateAsync(id, addressDto);
                return Ok(updatedAddress);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            var result = await _addressService.DeleteAsync(id);
            if (result)
            {
                return Ok("Deleted Successfully");
            }
            return NotFound($"Address with ID {id} not found or not deleted.");

        }
    }
}
