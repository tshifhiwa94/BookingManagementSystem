using AutoMapper;
using BookingManagement.Domain.Branches;
using BookingManagement.Domain.Departments;
using BookingManagement.Domain.Resources;
using BookingManagement.Repositories.BranchRepository;
using BookingManagement.Repositories.DepartmentsRepository;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Repositories.ResourcesRepository;
using BookingManagement.Services.ResourcesService;
using BookingManagement.Services.ResourcesService.Dtos;
using Moq;
using System.Linq.Expressions;

namespace BookingManagement.Test.Services
{
    public class ResourceServiceTests
    {
        private readonly Mock<IResourceRepository> _resourceRepoMock;
        private readonly Mock<IBranchRepository> _branchRepoMock;
        private readonly Mock<IDepartmentRepository> _departmentRepoMock;
        private readonly Mock<IResourceRequestRepository> _resourceRequestRepoMock;
        private readonly Mock<IPersonRepository> _personRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ResourceService _resourceService;
        private readonly ResourceRequestService _resourceRequestService;
        public ResourceServiceTests()
        {
            _branchRepoMock = new Mock<IBranchRepository>();
            _departmentRepoMock = new Mock<IDepartmentRepository>();
            _resourceRepoMock = new Mock<IResourceRepository>();
            _resourceRequestRepoMock = new Mock<IResourceRequestRepository>();
            _personRepoMock = new Mock<IPersonRepository>();
            _mapperMock = new Mock<IMapper>();

            _resourceService = new ResourceService(
                _resourceRepoMock.Object,
                _departmentRepoMock.Object,
                _branchRepoMock.Object,
                _mapperMock.Object
            );

            _resourceRequestService = new ResourceRequestService(
                _resourceRequestRepoMock.Object,
                _resourceRepoMock.Object,
                _personRepoMock.Object,
                _mapperMock.Object
            );
        }

        #region ResourceService Test Methods

        [Fact]
        public async Task CreateAsync_ShouldReturnResourceDto_WhenInputIsValid()
        {
            // Arrange
            var branchId = Guid.NewGuid();
            var departmentId = Guid.NewGuid();
            var createResourceDto = new CreateResourceDto
            {
                Name = "Projector",
                Description = "A high-quality projector",
                BranchId = branchId,
                DepartmentId = departmentId
            };
            var branch = new Branch { Id = branchId, Name = "Main Branch" };
            var department = new Department { Id = departmentId, Name = "IT Department" };
            var resource = new Resource
            {
                Id = Guid.NewGuid(),
                Name = createResourceDto.Name,
                Description = createResourceDto.Description,
                Branch = branch,
                Department = department
            };
            var resourceDto = new ResourceDto
            {
                Id = resource.Id,
                Name = resource.Name,
                Description = resource.Description
            };

            _branchRepoMock.Setup(b => b.GetAsync(branchId)).ReturnsAsync(branch);
            _departmentRepoMock.Setup(d => d.GetAsync(departmentId)).ReturnsAsync(department);
            _mapperMock.Setup(m => m.Map<Resource>(createResourceDto)).Returns(resource);
            _resourceRepoMock.Setup(r => r.AddAsync(resource)).ReturnsAsync(resource);
            _mapperMock.Setup(m => m.Map<ResourceDto>(resource)).Returns(resourceDto);
            // Act
            var result = await _resourceService.CreateAsync(createResourceDto);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(resourceDto.Id, result.Id);
            Assert.IsType<ResourceDto>(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenResourceExists()
        {
            // Arrange
            var resourceId = Guid.NewGuid();
            var resource = new Resource { Id = resourceId };
            _resourceRepoMock.Setup(r => r.GetAsync(resourceId)).ReturnsAsync(resource);
            _resourceRepoMock.Setup(r => r.DeleteAsync(resource)).ReturnsAsync(true);
            // Act
            var result = await _resourceService.DeleteAsync(resourceId);
            // Assert
            Assert.True(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenResourceDoesNotExist()
        {
            // Arrange
            var resourceId = Guid.NewGuid();
            _resourceRepoMock.Setup(r => r.GetAsync(resourceId)).ReturnsAsync((Resource)null);
            // Act
            var result = await _resourceService.DeleteAsync(resourceId);
            // Assert
            Assert.False(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfResourceDto_WhenResourcesExist()
        {
            // Arrange
            var resources = new List<Resource>
            {
                new Resource { Id = Guid.NewGuid(), Name = "Projector", Description = "A high-quality projector" },
                new Resource { Id = Guid.NewGuid(), Name = "Laptop", Description = "A powerful laptop" }
            };
            _resourceRepoMock
                        .Setup(r => r.GetAllAsync(
                            It.IsAny<Expression<Func<Resource, object>>>(),
                            It.IsAny<Expression<Func<Resource, object>>>()
                        ))
                        .ReturnsAsync(resources);

            _mapperMock.Setup(m => m.Map<List<ResourceDto>>(resources)).Returns(new List<ResourceDto>
            {
                new ResourceDto { Id = resources[0].Id, Name = resources[0].Name, Description = resources[0].Description },
                new ResourceDto { Id = resources[1].Id, Name = resources[1].Name, Description = resources[1].Description }
            });
            // Act
            var result = await _resourceService.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(resources.Count, result.Count());
        }


        [Fact]
        public async Task GetAsync_ShouldReturnNull_WhenResourceDoesNotExist()
        {
            // Arrange
            var resourceId = Guid.NewGuid();
            _resourceRepoMock.Setup(r => r.GetAsync(resourceId, It.IsAny<Expression<Func<Resource, object>>>(), It.IsAny<Expression<Func<Resource, object>>>()))
                .ReturnsAsync((Resource)null);
            // Act
            var result = await _resourceService.GetAsync(resourceId);
            // Assert
            Assert.Null(result);
        }



        #endregion
    }
}
