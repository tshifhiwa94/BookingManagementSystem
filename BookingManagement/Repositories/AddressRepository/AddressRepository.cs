using BookingManagement.Data;
using BookingManagement.Domain.Addresses;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories
{
    public class AddressRepository : BaseRepository<Address, Guid>, IAddressRepository
    {
        public AddressRepository(BookManagementDbContext context) : base(context)
        {

        }

    }
}
