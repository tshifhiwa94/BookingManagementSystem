using BookingManagement.Data;
using BookingManagement.Domain.Branches;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories.BranchRepository
{
    public class BranchRepository : BaseRepository<Branch, Guid>, IBranchRepository
    {
        public BranchRepository(BookManagementDbContext context) : base(context)
        {
        }
    }
}
