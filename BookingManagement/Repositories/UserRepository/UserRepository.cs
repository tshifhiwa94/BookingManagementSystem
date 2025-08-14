using BookingManagement.Data;
using BookingManagement.Domain.Users;
using BookingManagement.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingManagement.Repositories.UserRepository
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository
    {
        private readonly BookManagementDbContext _context;
        public UserRepository(BookManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> ValidateRefreshTokenAsync(string userId, string refreshToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId && u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                return null; // Invalid or expired refresh token
            }
            return user;
        }
    }
}
