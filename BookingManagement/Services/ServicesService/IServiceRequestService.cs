using BookingManagement.Services.ServicesService.Dtos;

namespace BookingManagement.Services.ServicesService
{
    public interface IServiceRequestService
    {
        Task<ServiceRequestDto> CreateAsync(CreateServiceRequestDto input);
        Task<ServiceRequestDto> GetAsync(Guid id);
        Task<List<ServiceRequestDto>> GetAllAsync();
        Task<ServiceRequestDto> UpdateAsync(UpdateServiceRequestDto input);
        Task<bool> DeleteAsync(Guid id);
    }
}
