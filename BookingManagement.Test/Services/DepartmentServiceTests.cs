using AutoMapper;
using BookingManagement.Domain.Branches;
using BookingManagement.Domain.Departments;
using BookingManagement.Domain.Persons;
using BookingManagement.Repositories.BranchRepository;
using BookingManagement.Repositories.DepartmentsRepository;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Services.DepartmentsService;
using BookingManagement.Services.DepartmentsService.Dtos;
using Moq;
using System.Linq.Expressions;

namespace BookingManagement.Test.Services
{
    public class DepartmentServiceTests
    {
        private readonly Mock<IDepartmentRepository> _departmentRepoMock;
        private readonly Mock<IBranchRepository> _branchRepoMock;
        private readonly Mock<IPersonRepository> _personRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly DepartmentService _departmentService;

        public DepartmentServiceTests()
        {
            _departmentRepoMock = new Mock<IDepartmentRepository>();
            _branchRepoMock = new Mock<IBranchRepository>();
            _personRepoMock = new Mock<IPersonRepository>();
            _mapperMock = new Mock<IMapper>();
            _departmentService = new DepartmentService(_departmentRepoMock.Object, _branchRepoMock.Object, _personRepoMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task CreateAsync_ShouldReturnDepartmentDto_WhenInputIsValid()
        {
            // Arrange
            var branchId = Guid.NewGuid();
            var createDepartmentDto = GetDummyCreateDepartmentDto(branchId);

            var department = new Department { Id = Guid.NewGuid(), Name = createDepartmentDto.Name };

            var departmentDto = new DepartmentDto { Id = department.Id, Name = department.Name };

            _mapperMock.Setup(m => m.Map<Department>(createDepartmentDto)).Returns(department);
            _branchRepoMock.Setup(r => r.GetAsync(branchId)).ReturnsAsync(new Branch { Id = branchId });
            _personRepoMock.Setup(r => r.GetAsync(createDepartmentDto.HeadOfDepartmentId)).ReturnsAsync(new Person { Id = createDepartmentDto.HeadOfDepartmentId });
            _departmentRepoMock.Setup(r => r.AddAsync(department)).ReturnsAsync(department);
            _mapperMock.Setup(m => m.Map<DepartmentDto>(department)).Returns(departmentDto);
            // Act

            var result = await _departmentService.CreateAsync(createDepartmentDto);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<DepartmentDto>(result);
            Assert.Equal(departmentDto.Name, result.Name);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenDepartmentExists()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            var department = new Department { Id = departmentId };
            _departmentRepoMock.Setup(r => r.GetAsync(departmentId)).ReturnsAsync(department);
            _departmentRepoMock.Setup(r => r.DeleteAsync(department)).ReturnsAsync(true);
            // Act
            var result = await _departmentService.DeleteAsync(departmentId);
            // Assert
            Assert.NotNull(result);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenDepartmentDoesNotExist()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            _departmentRepoMock.Setup(r => r.GetAsync(departmentId)).ReturnsAsync((Department)null);
            // Act
            var result = await _departmentService.DeleteAsync(departmentId);
            // Assert
            Assert.NotNull(result);
            Assert.False(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfDepartmentDto()
        {
            // Arrange
            var departments = GetDummyDepartmentDtoList();
            _departmentRepoMock.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<Department, object>>>(), It.IsAny<Expression<Func<Department, object>>>()))
                .ReturnsAsync(departments.Select(d => new Department { Id = d.Id, Name = d.Name, Description = d.Description }).ToList());
            _mapperMock.Setup(m => m.Map<List<DepartmentDto>>(It.IsAny<List<Department>>())).Returns(departments);
            // Act
            var result = await _departmentService.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<DepartmentDto>>(result);
            Assert.Equal(departments.Count, result.Count);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnDepartmentDto_WhenDepartmentExists()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            var department = new Department { Id = departmentId, Name = "Finance", Description = "Handles all financial operations" };

            _departmentRepoMock.Setup(r => r.GetAsync(departmentId, It.IsAny<Expression<Func<Department, object>>>(), It.IsAny<Expression<Func<Department, object>>>()))
                .ReturnsAsync(department);

            _mapperMock.Setup(m => m.Map<DepartmentDto>(department)).Returns(new DepartmentDto { Id = department.Id, Name = department.Name, Description = department.Description });

            // Act

            var result = await _departmentService.GetAsync(departmentId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DepartmentDto>(result);
            Assert.Equal(department.Name, result.Name);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull_WhenDepartmentDoesNotExist()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            _departmentRepoMock.Setup(r => r.GetAsync(departmentId, It.IsAny<Expression<Func<Department, object>>>(), It.IsAny<Expression<Func<Department, object>>>()))
                .ReturnsAsync((Department)null);
            // Act
            var result = await _departmentService.GetAsync(departmentId);
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnDepartmentDto_WhenDepartmentExists()
        {
            // Arrange
            var departmentId = Guid.NewGuid();

            var inputDto = new DepartmentDto
            {
                Id = departmentId,
                Name = "Updated Department",
                Description = "Updated Description"
            };

            var existingDepartment = new Department
            {
                Id = departmentId,
                Name = "Old Department",
                Description = "Old Description",
            };

            var updatedDepartment = new Department
            {
                Id = departmentId,
                Name = inputDto.Name,
                Description = inputDto.Description
            };

            var expectedDto = new DepartmentDto
            {
                Id = departmentId,
                Name = inputDto.Name,
                Description = inputDto.Description
            };

            _departmentRepoMock.Setup(r => r.GetAsync(departmentId))
                               .ReturnsAsync(existingDepartment);


            _mapperMock.Setup(r => r.Map<DepartmentDto>(existingDepartment))
                        .Returns(new DepartmentDto
                        {
                            Id = expectedDto.Id,
                            Name = expectedDto.Name,
                            Description = expectedDto.Description
                        });

            _departmentRepoMock.Setup(r => r.UpdateAsync(existingDepartment))
                               .ReturnsAsync(updatedDepartment);

            _mapperMock.Setup(m => m.Map<DepartmentDto>(updatedDepartment))
                       .Returns(expectedDto);

            // Act
            var result = await _departmentService.UpdateAsync(inputDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Name, result.Name);
            Assert.Equal(expectedDto.Description, result.Description);
        }


        #region

        private CreateDepartmentDto GetDummyCreateDepartmentDto(Guid id)
        {
            return new CreateDepartmentDto
            {
                Name = "Finance",
                Description = "Handles all financial operations",
                HeadOfDepartmentId = Guid.NewGuid(),
                BranchId = id
            };
        }

        private List<DepartmentDto> GetDummyDepartmentDtoList()
        {
            return new List<DepartmentDto>
                {
                    new DepartmentDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Human Resources",
                        Description = "Manages employee relations"
                    },
                    new DepartmentDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "IT",
                        Description = "Maintains tech infrastructure"
                    },
                    new DepartmentDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Marketing",
                        Description = "Promotes company services"
                    }
                };
        }

        private DepartmentDto GetDummyUpdateDepartmentDto()
        {
            return new DepartmentDto
            {
                Id = Guid.NewGuid(),
                Name = "Operations",
                Description = "Oversees daily business activities"
            };
        }
        #endregion
    }
}
