using BookingManagement.Services.ServicesService.Dtos;

namespace BookingManagement.Services.ServicesService
{
    public interface IServiceService
    {

        Task<ServiceDto> CreateAsync(CreateServiceDto input);
        Task<ServiceDto> GetAsync(Guid id);
        Task<IEnumerable<ServiceDto>> GetAllAsync();
        Task<ServiceDto> UpdateAsync(UpdateServiceDto input);
        Task<bool> DeleteAsync(Guid id);
    }
}
