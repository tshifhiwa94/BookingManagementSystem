using BookingManagement.Data;
using BookingManagement.Domain.Departments;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories.DepartmentsRepository
{
    public class DepartmentRepository : BaseRepository<Department, Guid>, IDepartmentRepository
    {
        public DepartmentRepository(BookManagementDbContext context) : base(context)
        {

        }
    }
}
