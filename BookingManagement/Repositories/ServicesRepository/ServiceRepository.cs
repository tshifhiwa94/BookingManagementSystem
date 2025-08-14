using BookingManagement.Data;
using BookingManagement.Domain.Services;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories.ServicesRepository
{
    public class ServiceRepository : BaseRepository<Service, Guid>, IServiceRepository
    {
        public ServiceRepository(BookManagementDbContext context) : base(context)
        {
        }
    }

}
