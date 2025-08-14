using BookingManagement.Data;
using BookingManagement.Domain.Services;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories.ServicesRepository
{
    public class ServiceRequestRepository : BaseRepository<ServiceRequest, Guid>, IServiceRequestRepository
    {
        public ServiceRequestRepository(BookManagementDbContext context) : base(context)
        {

        }
    }
}
