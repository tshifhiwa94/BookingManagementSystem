using AutoMapper;
using BookingManagement.Domain.Addresses;
using BookingManagement.Repositories;
using BookingManagement.Services.AddressService;
using BookingManagement.Services.AddressService.Dtos;
using Moq;

namespace BookingManagement.Test.Services
{
    public class AddressServiceTests
    {
        private readonly Mock<IAddressRepository> _addressRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly AddressService _addressService;
        public AddressServiceTests()
        {
            _addressRepoMock = new Mock<IAddressRepository>();
            _mapperMock = new Mock<IMapper>();
            _addressService = new AddressService(_addressRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedAddressDto()
        {
            // Arrange
            var addressDto = new AddressDto { Id = Guid.NewGuid(), Street = "123 Main St" };
            var addressEntity = new Address { Id = addressDto.Id, Street = addressDto.Street };
            _mapperMock.Setup(m => m.Map<Address>(addressDto)).Returns(addressEntity);
            _mapperMock.Setup(m => m.Map<AddressDto>(addressEntity)).Returns(addressDto);
            _addressRepoMock.Setup(repo => repo.AddAsync(It.IsAny<Address>())).ReturnsAsync(addressEntity);
            // Act
            var result = await _addressService.CreateAsync(addressDto);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(addressDto.Id, result.Id);
            Assert.Equal(addressDto.Street, result.Street);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllAddressDtos()
        {
            // Arrange
            var addressEntities = new List<Address>
            {
                new Address { Id = Guid.NewGuid(), Street = "123 Main St" },
                new Address { Id = Guid.NewGuid(), Street = "456 Elm St" }
            };
            var addressDtos = addressEntities.Select(a => new AddressDto { Id = a.Id, Street = a.Street }).ToList();
            _addressRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(addressEntities);
            _mapperMock.Setup(m => m.Map<IEnumerable<AddressDto>>(addressEntities)).Returns(addressDtos);
            // Act
            var result = await _addressService.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnAddressDto_WhenExists()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            var addressEntity = new Address { Id = addressId, Street = "123 Main St" };
            var addressDto = new AddressDto { Id = addressId, Street = "123 Main St" };
            _addressRepoMock.Setup(repo => repo.GetAsync(addressId)).ReturnsAsync(addressEntity);
            _mapperMock.Setup(m => m.Map<AddressDto>(addressEntity)).Returns(addressDto);
            // Act
            var result = await _addressService.GetAsync(addressId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(addressId, result.Id);
        }

        [Fact]
        public async Task GetAsync_ShouldThrowKeyNotFoundException_WhenAddressDoesNotExist()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            _addressRepoMock.Setup(repo => repo.GetAsync(addressId)).ReturnsAsync((Address)null);
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _addressService.GetAsync(addressId));
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedAddressDto_WhenExists()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            var existingAddress = new Address { Id = addressId, Street = "123 Main St" };
            var updateDto = new UpdateAddressDto { Street = "789 Oak St" };
            var updatedAddress = new Address { Id = addressId, Street = updateDto.Street };
            var updatedAddressDto = new AddressDto { Id = addressId, Street = updateDto.Street };

            _addressRepoMock.Setup(repo => repo.GetAsync(addressId)).ReturnsAsync(existingAddress);
            _mapperMock.Setup(m => m.Map(updateDto, existingAddress)).Verifiable();
            _addressRepoMock.Setup(repo => repo.UpdateAsync(existingAddress)).ReturnsAsync(updatedAddress);
            _mapperMock.Setup(m => m.Map<AddressDto>(updatedAddress)).Returns(updatedAddressDto);

            // Act
            var result = await _addressService.UpdateAsync(addressId, updateDto);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<AddressDto>(result);
            Assert.Equal(updatedAddressDto.Id, result.Id);
            Assert.Equal(updatedAddressDto.Street, result.Street);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowKeyNotFoundException_WhenAddressDoesNotExist()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            var updateDto = new UpdateAddressDto { Street = "789 Oak St" };
            _addressRepoMock.Setup(repo => repo.GetAsync(addressId)).ReturnsAsync((Address)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _addressService.UpdateAsync(addressId, updateDto));
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenAddressExists()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            var existingAddress = new Address { Id = addressId };
            _addressRepoMock.Setup(repo => repo.GetAsync(addressId)).ReturnsAsync(existingAddress);
            _addressRepoMock.Setup(repo => repo.DeleteAsync(existingAddress)).ReturnsAsync(true);
            // Act
            var result = await _addressService.DeleteAsync(addressId);
            // Assert
            Assert.NotNull(result);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenAddressDoesNotExist()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            _addressRepoMock.Setup(repo => repo.GetAsync(addressId)).ReturnsAsync((Address)null);
            // Act
            var result = await _addressService.DeleteAsync(addressId);
            // Assert
            Assert.NotNull(result);
            Assert.False(result);
        }

    }
}
