using BookingManagement.Services.DepartmentsService.Dtos;

namespace BookingManagement.Services.DepartmentsService
{
    public interface IDepartmentService
    {

        Task<DepartmentDto> CreateAsync(CreateDepartmentDto input);
        Task<DepartmentDto> GetAsync(Guid id);
        Task<List<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> UpdateAsync(DepartmentDto input);
        Task<bool> DeleteAsync(Guid id);
    }
}
