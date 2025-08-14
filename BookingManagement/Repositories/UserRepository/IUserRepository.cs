using BookingManagement.Domain.Users;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User, string>
    {
        Task<User> ValidateRefreshTokenAsync(string UserId, string refreshToken);
    }
}
