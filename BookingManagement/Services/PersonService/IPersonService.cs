using BookingManagement.Services.PersonService.Dtos;

namespace BookingManagement.Services.PersonService
{
    public interface IPersonService
    {
        Task<PersonDto> GetAsync(Guid id);
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto> CreateAsync(PersonDto input);
        Task<PersonDto> UpdateAsync(PersonDto personDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
