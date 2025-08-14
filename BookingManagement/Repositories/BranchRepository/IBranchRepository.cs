using BookingManagement.Domain.Branches;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories.BranchRepository
{
    public interface IBranchRepository : IBaseRepository<Branch, Guid>
    {
    }
}
