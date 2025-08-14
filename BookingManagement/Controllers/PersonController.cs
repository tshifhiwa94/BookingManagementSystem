using AutoMapper;
using BookingManagement.Services.PersonService;
using BookingManagement.Services.PersonService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreatePerson(PersonDto personDto)
        {
            if (personDto == null)
            {
                return BadRequest("Person data is required.");
            }

            return Ok(await _personService.CreateAsync(personDto));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllPersons()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            var person = await _personService.GetAsync(id);
            if (person == null)
            {
                return NotFound($"Person with ID {id} not found.");
            }
            return Ok(person);
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var result = await _personService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Person with ID {id} not found.");
            }
            return NoContent(); // 204 No Content
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdatePerson(PersonDto personDto)
        {
            if (personDto == null)
            {
                return BadRequest("Person data with valid ID is required.");
            }
            var updatedPerson = await _personService.UpdateAsync(personDto);
            return Ok(updatedPerson);
        }
    }
}
