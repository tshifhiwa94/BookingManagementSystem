using BookingManagement.Domain.Addresses;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories
{
    public interface IAddressRepository : IBaseRepository<Address, Guid>
    {
    }
}
