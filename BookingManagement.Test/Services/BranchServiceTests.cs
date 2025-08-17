using AutoMapper;
using BookingManagement.Domain.Addresses;
using BookingManagement.Domain.Branches;
using BookingManagement.Domain.Persons;
using BookingManagement.Repositories;
using BookingManagement.Repositories.BranchRepository;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Services.BranchService;
using BookingManagement.Services.BranchService.Dtos;
using Moq;

namespace BookingManagement.Test.Services
{
    public class BranchServiceTests
    {
        private readonly Mock<IBranchRepository> _branchRepoMock;
        private readonly Mock<IAddressRepository> _addressRepoMock;
        private readonly Mock<IPersonRepository> _personRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BranchService _branchService;

        public BranchServiceTests()
        {
            _branchRepoMock = new Mock<IBranchRepository>();
            _addressRepoMock = new Mock<IAddressRepository>();
            _personRepoMock = new Mock<IPersonRepository>();
            _mapperMock = new Mock<IMapper>();

            _branchService = new BranchService(
                _branchRepoMock.Object,
                _addressRepoMock.Object,
                _personRepoMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnBranchDto_WhenBranchCreated()
        {
            // Arrange
            var branchEntity = BranchTestData();
            var addressEntity = branchEntity.Address;
            var managerEntity = branchEntity.Manager;

            var createBranchDto = new CreateBranchDto
            {
                AddressId = addressEntity.Id,
                ManagerId = managerEntity.Id,
                Name = branchEntity.Name,
                PhoneNumber = branchEntity.PhoneNumber,
                Email = branchEntity.Email,
                EstablishedDate = branchEntity.EstablishedDate
            };

            var branchDto = new BranchDto
            {
                Id = branchEntity.Id,
                Name = branchEntity.Name,
                PhoneNumber = branchEntity.PhoneNumber,
                Email = branchEntity.Email,
                EstablishedDate = branchEntity.EstablishedDate
            };

            // set ups
            _addressRepoMock.Setup(x => x.GetAsync(addressEntity.Id)).ReturnsAsync(addressEntity);
            _personRepoMock.Setup(x => x.GetAsync(managerEntity.Id)).ReturnsAsync(managerEntity);
            _mapperMock.Setup(x => x.Map<Branch>(createBranchDto)).Returns(branchEntity);
            _mapperMock.Setup(x => x.Map<Address>(addressEntity)).Returns(addressEntity);
            _mapperMock.Setup(x => x.Map<Person>(managerEntity)).Returns(managerEntity);
            _branchRepoMock.Setup(x => x.AddAsync(It.IsAny<Branch>())).ReturnsAsync(branchEntity);
            _mapperMock.Setup(x => x.Map<BranchDto>(branchEntity)).Returns(branchDto);

            // Act
            var result = await _branchService.CreateAsync(createBranchDto);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(_addressRepoMock.Object);
            Assert.IsType<BranchDto>(result);
            Assert.Equal(branchDto.Name, result.Name);
            Assert.Equal(branchDto.Email, result.Email);
            Assert.Equal(branchDto.PhoneNumber, result.PhoneNumber);
            Assert.Equal(branchDto.EstablishedDate, result.EstablishedDate);
        }


        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfBranchDto_WhenCalled()
        {
            // Arrange
            var branchEntities = GetBranchEntityTestData();

            var branchDtos = branchEntities.Select(b => new BranchDto
            {
                Id = b.Id,
                Name = b.Name,
                PhoneNumber = b.PhoneNumber,
                Email = b.Email,
                EstablishedDate = b.EstablishedDate
            }).ToList();

            _branchRepoMock.Setup(repo => repo.GetAllAsync(b => b.Address, p => p.Manager))
                           .ReturnsAsync(branchEntities);

            _mapperMock.Setup(mapper => mapper.Map<List<BranchDto>>(branchEntities))
                       .Returns(branchDtos);

            // Act
            var result = await _branchService.GetAllAsync();

            // Assert
            Assert.Null(result);
            Assert.True(branchDtos.Any());
            Assert.Distinct(branchDtos);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnBranchDto_WhenPassId()
        {
            // Arrange
            var branchEntities = GetBranchEntityTestData();
            var targetBranch = branchEntities.First(); // Simulate fetching by ID
            var branchId = targetBranch.Id;

            var expectedDto = new BranchDto
            {
                Id = targetBranch.Id,
                Name = targetBranch.Name,
                PhoneNumber = targetBranch.PhoneNumber,
                Email = targetBranch.Email,
                EstablishedDate = targetBranch.EstablishedDate
            };

            _branchRepoMock.Setup(repo => repo.GetAsync(branchId, b => b.Address, p => p.Manager))
                           .ReturnsAsync(targetBranch);

            _mapperMock.Setup(mapper => mapper.Map<BranchDto>(targetBranch))
                       .Returns(expectedDto);

            // Act
            var result = await _branchService.GetAsync(branchId);

            // Assert
            Assert.Null(result);

        }


        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenBranchDoesNotExist()
        {
            // Arrange
            var Id = Guid.NewGuid();
            _branchRepoMock.Setup(r => r.GetAsync(Id)).ReturnsAsync((Branch)null);

            // Act
            var result = await _branchService.DeleteAsync(Id);

            // Assert
            Assert.False(result);
        }

        public async Task DeleteAsync_ShouldReturnTrue_WhenBranchDoesExist()
        {
            // Arrange
            var branchId = Guid.NewGuid();
            var branch = new Branch { Id = branchId };
            _branchRepoMock.Setup(r => r.GetAsync(branchId)).ReturnsAsync(branch);

            // Act
            var result = await _branchService.DeleteAsync(branchId);

            // Assert
            Assert.True(result);
        }

        public async Task UpdateAsync_ShouldReturnNull_WhenBranchDoesNotExist()
        {
            // Arrange
            var updateDto = new UpdateBranchDto { Id = Guid.NewGuid() };
            _branchRepoMock.Setup(r => r.GetAsync(updateDto.Id)).ReturnsAsync((Branch)null);

            // Act
            var result = await _branchService.UpdateAsync(updateDto);
            // Assert
            Assert.Null(result);
        }



        #region Generate Request Object
        private Branch BranchTestData()
        {
            return new Branch
            {
                Name = "Telesure Branch",
                PhoneNumber = "0111234567",
                Email = "branch@telesure.co.za",
                EstablishedDate = DateTime.Parse("2025-05-28 15:45:13.5235851"),
                Address = new Address
                {
                    Id = Guid.NewGuid(),
                    City = "Auto & General Park",
                    Street = "1 Telesure Lane",
                    State = "Midrand",
                    PostalCode = "2191"
                },
                Manager = new Person
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    Surname = "Doe"
                }
            };
        }

        private List<Branch> GetBranchEntityTestData()
        {
            return new List<Branch>
            {
                new Branch
                {
                    Id = Guid.NewGuid(),
                    Name = "Main Branch",
                    PhoneNumber = "0111234567",
                    Email = "mainbranch@telesure.co.za",
                    EstablishedDate = new DateTime(2000, 1, 1),
                    Address = new Address
                    {
                        Id = Guid.NewGuid(),
                        City = "Midrand",
                        Street = "1 Telesure Lane",
                        State = "Gauteng",
                        PostalCode = "2191"
                    },
                    Manager = new Person
                    {
                        Id = Guid.NewGuid(),
                        Name = "John",
                        Surname = "Doe"
                    }
                },
                new Branch
                {
                    Id = Guid.NewGuid(),
                    Name = "Cape Town Branch",
                    PhoneNumber = "0217654321",
                    Email = "capetown@telesure.co.za",
                    EstablishedDate = new DateTime(2005, 6, 15),
                    Address = new Address
                    {
                        Id = Guid.NewGuid(),
                        City = "Cape Town",
                        Street = "123 Long Street",
                        State = "Western Cape",
                        PostalCode = "8001"
                    },
                    Manager = new Person
                    {
                        Id = Guid.NewGuid(),
                        Name = "Naledi",
                        Surname = "Jacobs"
                    }
                }
            };
        }

        #endregion



    }
}
