using BookingManagement.Domain.Departments;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories.DepartmentsRepository
{
    public interface IDepartmentRepository : IBaseRepository<Department, Guid>
    {
    }
}
