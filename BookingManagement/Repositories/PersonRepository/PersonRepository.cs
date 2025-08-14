using BookingManagement.Data;
using BookingManagement.Domain.Persons;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories.PersonRepository
{
    public class PersonRepository : BaseRepository<Person, Guid>, IPersonRepository
    {
        public PersonRepository(BookManagementDbContext context) : base(context)
        {

        }
    }
}
