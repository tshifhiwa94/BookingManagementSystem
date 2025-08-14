using BookingManagement.Domain.Services;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories.ServicesRepository
{
    public interface IServiceRepository : IBaseRepository<Service, Guid>
    {
    }
}
