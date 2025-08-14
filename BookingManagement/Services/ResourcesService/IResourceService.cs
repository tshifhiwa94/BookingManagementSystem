using BookingManagement.Services.ResourcesService.Dtos;

namespace BookingManagement.Services.ResourcesService
{
    public interface IResourceService
    {
        Task<ResourceDto> CreateAsync(CreateResourceDto input);
        Task<ResourceDto> GetAsync(Guid id);
        Task<IEnumerable<ResourceDto>> GetAllAsync();
        Task<ResourceDto> UpdateAsync(UpdateResourceDto input);
        Task<bool> DeleteAsync(Guid id);
    }
}
