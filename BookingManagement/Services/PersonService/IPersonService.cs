using BookingManagement.Services.PersonService.Dtos;

namespace BookingManagement.Services.PersonService
{
    public interface IPersonService
    {
        Task<PersonDto> GetAsync(Guid id);
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto> CreateAsync(CreatePersonDto input);
        Task<PersonDto> UpdateAsync(UpdatePersonDto personDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
