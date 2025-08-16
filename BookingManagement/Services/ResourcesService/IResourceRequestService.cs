using BookingManagement.Services.ResourcesService.Dtos;

namespace BookingManagement.Services.ResourcesService
{
    public interface IResourceRequestService
    {
        Task<ResourceRequestDto> CreateAsync(CreateResourceRequestDto input);
        Task<ResourceRequestDto> GetAsync(Guid id);
        Task<List<ResourceRequestDto>> GetAllAsync();
        Task<ResourceRequestDto> UpdateAsync(UpdateResourceRequestDto input);
        Task<bool> DeleteAsync(Guid id);
    }
}
