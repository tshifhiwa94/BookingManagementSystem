using BookingManagement.Domain.Resources;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories.ResourcesRepository
{
    public interface IResourceRepository : IBaseRepository<Resource, Guid>
    {
    }
}
