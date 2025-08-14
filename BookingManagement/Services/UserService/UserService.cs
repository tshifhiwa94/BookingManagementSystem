using AutoMapper;
using BookingManagement.Domain.Users;
using BookingManagement.Repositories.UserRepository;
using BookingManagement.Services.UserService.Dtos;

namespace BookingManagement.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateAsync(CreateUserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto), "User DTO cannot be null");
            }
            var user = _mapper.Map<User>(userDto);
            await _userRepo.AddAsync(user);
            var userDtoResult = _mapper.Map<UserDto>(user);
            return userDtoResult;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await _userRepo.GetAsync(id.ToString());
            if (user == null)
            {
                return false;
            }
            await _userRepo.DeleteAsync(user);
            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userRepo.GetAllAsync());
        }

        public async Task<UserDto> GetAsync(string id)
        {
            var user = await _userRepo.GetAsync(id);
            if (user == null) { return null; }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateAsync(string id, UpdateUserDto userDto)
        {
            var user = await _userRepo.GetAsync(id);
            if (user == null)
            {
                return null;
            }
            // Use AutoMapper to map to the existing entity
            _mapper.Map(userDto, user);

            return _mapper.Map<UserDto>(await _userRepo.UpdateAsync(user));
        }
    }
}
