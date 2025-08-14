using BookingManagement.Domain.Persons;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories.PersonRepository
{
    public interface IPersonRepository : IBaseRepository<Person, Guid>
    {
    }
}
