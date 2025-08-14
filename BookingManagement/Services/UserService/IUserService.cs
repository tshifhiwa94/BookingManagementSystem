using BookingManagement.Services.UserService.Dtos;

namespace BookingManagement.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto userDto);

        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(string id);

        Task<UserDto> UpdateAsync(string id, UpdateUserDto personDto);
        Task<bool> DeleteAsync(string id);
    }
}
