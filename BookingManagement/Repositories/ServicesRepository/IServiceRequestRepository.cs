using BookingManagement.Domain.Services;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories.ServicesRepository
{
    public interface IServiceRequestRepository : IBaseRepository<ServiceRequest, Guid>
    {
    }
}
