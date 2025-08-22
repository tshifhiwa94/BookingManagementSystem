using AutoMapper;
using BookingManagement.Domain.Users;
using BookingManagement.Repositories.UserRepository;
using BookingManagement.Services.UserService;
using BookingManagement.Services.UserService.Dtos;
using Moq;

namespace BookingManagement.Test.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserService _userService;
        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnUserDto_WhenUserDtoIsValid()
        {
            // Arrange
            var userId = (Guid.NewGuid()).ToString();
            var createUserDto = new CreateUserDto
            {
                UserName = "John",
                Password = "Admin@123",
                Email = "admin@gmail.com",
                PhoneNumber = "0827466891"
            };

            var user = new User
            {
                Id = userId,
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                AccessFailedCount = 0
            };

            var userDto = new UserDto
            {
                Id = userId,
                UserName = createUserDto.UserName,
            };

            _mapperMock.Setup(m => m.Map<User>(createUserDto)).Returns(user);
            _userRepositoryMock.Setup(r => r.AddAsync(user)).ReturnsAsync(user);
            _mapperMock.Setup(m => m.Map<UserDto>(user)).Returns(userDto);

            // Act
            var result = await _userService.CreateAsync(createUserDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal(createUserDto.UserName, result.UserName);
        }


        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            // Arrange
            var userId = (Guid.NewGuid()).ToString();
            var user = new User { Id = userId };
            var isItemDeleted = true;
            _userRepositoryMock.Setup(r => r.GetAsync(userId)).ReturnsAsync(user);
            // Act
            var result = await _userService.DeleteAsync(userId);
            // Assert
            Assert.NotNull(result);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = (Guid.NewGuid()).ToString();
            _userRepositoryMock.Setup(r => r.GetAsync(userId)).ReturnsAsync((User)null);
            // Act
            var result = await _userService.DeleteAsync(userId);
            // Assert
            Assert.NotNull(result);
            Assert.False(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfUserDto_WhenUsersExist()
        {

            // Arrange
            var userId1 = (Guid.NewGuid()).ToString();
            var userId2 = (Guid.NewGuid()).ToString();

            var user1 = new User { Id = userId1, UserName = "User1" };
            var user2 = new User { Id = userId2, UserName = "User2" };
            var users = new List<User> { user1, user2 };
            var userDtos = new List<UserDto>
            {
                new UserDto { Id = userId1, UserName = "User1" },
                new UserDto { Id =userId2, UserName = "User2" }
            };
            _userRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);
            _mapperMock.Setup(m => m.Map<IEnumerable<UserDto>>(users)).Returns(userDtos);
            // Act
            var result = await _userService.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDtos.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnUserDto_WhenUserExists()
        {
            // Arrange
            var userId = (Guid.NewGuid()).ToString();
            var user = new User { Id = userId, UserName = "John" };
            var userDto = new UserDto { Id = userId, UserName = "John" };
            _userRepositoryMock.Setup(r => r.GetAsync(userId)).ReturnsAsync(user);
            _mapperMock.Setup(m => m.Map<UserDto>(user)).Returns(userDto);
            // Act
            var result = await _userService.GetAsync(userId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal(user.UserName, result.UserName);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = (Guid.NewGuid()).ToString();
            _userRepositoryMock.Setup(r => r.GetAsync(userId)).ReturnsAsync((User)null);
            // Act
            var result = await _userService.GetAsync(userId);
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedUserDto_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var updateUserDto = new UpdateUserDto
            {
                Email = "new@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0827466891",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            var existingUser = new User
            {
                Id = userId,
                Email = "oldEmail@mail.com",
                EmailConfirmed = false,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = true,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 1
            };

            var updatedUser = new User
            {
                Id = userId,
                Email = updateUserDto.Email,
                EmailConfirmed = updateUserDto.EmailConfirmed,
                PhoneNumber = updateUserDto.PhoneNumber,
                PhoneNumberConfirmed = updateUserDto.PhoneNumberConfirmed,
                TwoFactorEnabled = updateUserDto.TwoFactorEnabled,
                LockoutEnd = null,
                LockoutEnabled = updateUserDto.LockoutEnabled,
                AccessFailedCount = updateUserDto.AccessFailedCount
            };

            var userDto = new UserDto
            {
                Id = userId,
                Email = updateUserDto.Email,
                EmailConfirmed = updateUserDto.EmailConfirmed,
                PhoneNumber = updateUserDto.PhoneNumber,
                PhoneNumberConfirmed = updateUserDto.PhoneNumberConfirmed,
                TwoFactorEnabled = updateUserDto.TwoFactorEnabled,
                LockoutEnd = null,
                LockoutEnabled = updateUserDto.LockoutEnabled,
                AccessFailedCount = updateUserDto.AccessFailedCount
            };

            _userRepositoryMock.Setup(r => r.GetAsync(userId)).ReturnsAsync(existingUser);

            // This mocks the in-place mapping
            _mapperMock.Setup(m => m.Map(updateUserDto, existingUser)).Callback(() =>
            {
                existingUser.Email = updateUserDto.Email;
                existingUser.EmailConfirmed = updateUserDto.EmailConfirmed;
                existingUser.PhoneNumber = updateUserDto.PhoneNumber;
                existingUser.PhoneNumberConfirmed = updateUserDto.PhoneNumberConfirmed;
                existingUser.TwoFactorEnabled = updateUserDto.TwoFactorEnabled;
                existingUser.LockoutEnabled = updateUserDto.LockoutEnabled;
                existingUser.AccessFailedCount = updateUserDto.AccessFailedCount;
            });

            _userRepositoryMock.Setup(r => r.UpdateAsync(existingUser)).ReturnsAsync(existingUser);
            _mapperMock.Setup(m => m.Map<UserDto>(existingUser)).Returns(userDto);

            // Act
            var result = await _userService.UpdateAsync(userId, updateUserDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal(updateUserDto.Email, result.Email);
            Assert.IsType<UserDto>(result);
        }


    }
}

