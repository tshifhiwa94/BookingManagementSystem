using BookingManagement.Services.BranchService.Dtos;

namespace BookingManagement.Services.BranchService
{
    public interface IBranchService
    {
        Task<BranchDto> CreateAsync(CreateBranchDto iput);
        Task<BranchDto> GetAsync(Guid id);
        Task<IEnumerable<BranchDto>> GetAllAsync();
        Task<BranchDto> UpdateAsync(UpdateBranchDto input);
        Task<bool> DeleteAsync(Guid id);
    }
}
