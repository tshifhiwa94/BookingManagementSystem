using BookingManagement.Data;
using BookingManagement.Domain.Resources;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories.ResourcesRepository
{
    public class ResourceRepository : BaseRepository<Resource, Guid>, IResourceRepository
    {
        public ResourceRepository(BookManagementDbContext context) : base(context)
        {
        }
    }
}
