using BookingManagement.Data;
using BookingManagement.Domain.Resources;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories.ResourcesRepository
{
    public class ResourceRequestRepository : BaseRepository<ResourceRequest, Guid>, IResourceRequestRepository
    {
        public ResourceRequestRepository(BookManagementDbContext context) : base(context)
        {
        }
    }
}
