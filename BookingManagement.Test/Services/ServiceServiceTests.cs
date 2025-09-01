using AutoMapper;
using BookingManagement.Domain.Departments;
using BookingManagement.Domain.Persons;
using BookingManagement.Domain.Services;
using BookingManagement.Repositories.DepartmentsRepository;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Repositories.ServicesRepository;
using BookingManagement.Services.PersonService.Dtos;
using BookingManagement.Services.ServicesService;
using BookingManagement.Services.ServicesService.Dtos;
using Moq;

namespace BookingManagement.Test.Services
{
    public class ServiceServiceTests
    {
        private readonly Mock<IServiceRepository> _serviceRepoMock;
        private readonly Mock<IServiceRequestRepository> _serviceRequestRepoMock;
        private readonly Mock<IDepartmentRepository> _departmentRepoMock;
        private readonly ServiceService _serviceService;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPersonRepository> _personRepoMock;
        private readonly ServiceRequestService _serviceRequestService;

        public ServiceServiceTests()
        {

            _serviceRepoMock = new Mock<IServiceRepository>();
            _serviceRequestRepoMock = new Mock<IServiceRequestRepository>();
            _mapperMock = new Mock<IMapper>();
            _departmentRepoMock = new Mock<IDepartmentRepository>();
            _personRepoMock = new Mock<IPersonRepository>();

            _serviceService = new ServiceService(_serviceRepoMock.Object, _departmentRepoMock.Object, _mapperMock.Object);

            _serviceRequestService = new ServiceRequestService(
                _serviceRequestRepoMock.Object,
                _personRepoMock.Object,
                _serviceRepoMock.Object,
                _mapperMock.Object);
        }

        #region  Service Tests

        [Fact]
        public async Task CreateAsync_ShouldReturnServiceDto_WhenInputIsValid()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var departmentId = Guid.NewGuid();

            var createServiceDto = new CreateServiceDto
            {
                Name = "Test Service",
                Description = "Test Description"
            };

            var department = new Department { Id = departmentId, Name = "Test Department" };

            var service = new Service
            {
                Id = serviceId,
                Name = createServiceDto.Name,
                Description = createServiceDto.Description
            };
            var serviceDto = new ServiceDto
            {
                Id = serviceId,
                Name = service.Name,
                Description = service.Description
            };
            _mapperMock.Setup(m => m.Map<Service>(createServiceDto)).Returns(service);
            _departmentRepoMock.Setup(d => d.GetAsync(It.IsAny<Guid>())).ReturnsAsync(department); // Assuming no department is needed for this test
            _serviceRepoMock.Setup(r => r.AddAsync(service)).ReturnsAsync(service);
            _mapperMock.Setup(m => m.Map<ServiceDto>(service)).Returns(serviceDto);

            // Act
            var result = await _serviceService.CreateAsync(createServiceDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ServiceDto>(result);
            Assert.Equal(serviceDto.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenServiceExists()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var service = new Service { Id = serviceId };
            _serviceRepoMock.Setup(r => r.GetAsync(serviceId)).ReturnsAsync(service);
            _serviceRepoMock.Setup(r => r.DeleteAsync(service)).ReturnsAsync(true);
            // Act
            var result = await _serviceService.DeleteAsync(serviceId);
            // Assert
            Assert.True(result);
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
        }


        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenServiceNotExists()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            _serviceRepoMock.Setup(r => r.GetAsync(serviceId)).ReturnsAsync((Service)null);
            _serviceRepoMock.Setup(r => r.DeleteAsync(null)).ReturnsAsync(false);
            // Act
            var result = await _serviceService.DeleteAsync(serviceId);
            // Assert
            Assert.False(result);
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfServiceDto_WhenServicesExist()
        {
            // Arrange
            var service1 = new Service { Id = Guid.NewGuid(), Name = "Service 1" };
            var service2 = new Service { Id = Guid.NewGuid(), Name = "Service 2" };
            var services = new List<Service> { service1, service2 };
            var serviceDtos = new List<ServiceDto>
            {
                new ServiceDto { Id = service1.Id, Name = service1.Name },
                new ServiceDto { Id = service2.Id, Name = service2.Name }
            };

            _serviceRepoMock
                .Setup(r => r.GetAllAsync(x => x.Department))
                .ReturnsAsync(services);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<ServiceDto>>(services))
                .Returns(serviceDtos);

            // Act
            var result = await _serviceService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ServiceDto>>(result);
            Assert.Equal(serviceDtos.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnServiceDto_WhenServiceExists()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var service = new Service { Id = serviceId, Name = "Test Service" };
            var serviceDto = new ServiceDto { Id = serviceId, Name = "Test Service" };
            _serviceRepoMock.Setup(r => r.GetAsync(serviceId, s => s.Department)).ReturnsAsync(service);
            _mapperMock.Setup(m => m.Map<ServiceDto>(service)).Returns(serviceDto);
            // Act
            var result = await _serviceService.GetAsync(serviceId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<ServiceDto>(result);
            Assert.Equal(serviceDto.Id, result.Id);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull_WhenServiceDoesNotExist()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            _serviceRepoMock.Setup(r => r.GetAsync(serviceId, s => s.Department)).ReturnsAsync((Service)null);
            // Act
            var result = await _serviceService.GetAsync(serviceId);
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnServiceDto_WhenServiceExists()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var updateServiceDto = new UpdateServiceDto
            {
                Id = serviceId,
                Name = "Updated Service",
                Description = "Updated Description"
            };
            var service = new Service
            {
                Id = serviceId,
                Name = "Old Service",
                Description = "Old Description"
            };
            var updatedService = new Service
            {
                Id = serviceId,
                Name = updateServiceDto.Name,
                Description = updateServiceDto.Description
            };
            var updatedServiceDto = new ServiceDto
            {
                Id = serviceId,
                Name = updatedService.Name,
                Description = updatedService.Description
            };
            _serviceRepoMock.Setup(r => r.GetAsync(serviceId, s => s.Department)).ReturnsAsync(service);
            _mapperMock.Setup(m => m.Map(updateServiceDto, service)).Returns(updatedService);
            _serviceRepoMock.Setup(r => r.UpdateAsync(service)).ReturnsAsync(updatedService);
            _mapperMock.Setup(m => m.Map<ServiceDto>(updatedService)).Returns(updatedServiceDto);
            // Act
            var result = await _serviceService.UpdateAsync(updateServiceDto);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<ServiceDto>(result);
            Assert.Equal(updatedServiceDto.Id, result.Id);
        }


        #endregion

        #region Service Request Service Tests
        [Fact]
        public async Task CreateAsync_ShouldReturnServiceRequestDto_WhenInputIsValid()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var requesterId = Guid.NewGuid();
            var createServiceRequestDto = new CreateServiceRequestDto
            {
                ServiceId = serviceId,
                RequesterId = requesterId,
                Description = "Test Service Request"
            };
            var service = new Service { Id = serviceId };
            var serviceDto = new ServiceDto { Id = serviceId };
            var requester = new Person { Id = requesterId };
            var requesterDto = new PersonDto { Id = requesterId, Name = "John", Surname = "Doe" };
            var serviceRequest = new ServiceRequest
            {
                Id = Guid.NewGuid(),
                Service = service,
                Requester = requester,
                Description = createServiceRequestDto.Description
            };
            var serviceRequestDto = new ServiceRequestDto
            {
                Id = serviceRequest.Id,
                Service = serviceDto,
                Requester = requesterDto,
                Description = serviceRequest.Description
            };
            _serviceRepoMock.Setup(r => r.GetAsync(serviceId)).ReturnsAsync(service);
            _personRepoMock.Setup(r => r.GetAsync(requesterId)).ReturnsAsync(requester);
            _mapperMock.Setup(m => m.Map<Domain.Services.ServiceRequest>(createServiceRequestDto)).Returns(serviceRequest);
            _serviceRequestRepoMock.Setup(r => r.AddAsync(serviceRequest)).ReturnsAsync(serviceRequest);
            _mapperMock.Setup(m => m.Map<ServiceRequestDto>(serviceRequest)).Returns(serviceRequestDto);
            // Act
            var result = await _serviceRequestService.CreateAsync(createServiceRequestDto);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<ServiceRequestDto>(result);
            Assert.Equal(serviceRequestDto.Description, result.Description);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenServiceRequestExists()
        {
            // Arrange
            var serviceRequestId = Guid.NewGuid();
            var serviceRequest = new ServiceRequest { Id = serviceRequestId };
            _serviceRequestRepoMock.Setup(r => r.GetAsync(serviceRequestId)).ReturnsAsync(serviceRequest);
            _serviceRequestRepoMock.Setup(r => r.DeleteAsync(serviceRequest)).ReturnsAsync(true);
            // Act
            var result = await _serviceRequestService.DeleteAsync(serviceRequestId);
            // Assert
            Assert.True(result);
            Assert.IsType<bool>(result);
            Assert.NotNull(result);

        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenServiceRequestNotExists()
        {
            // Arrange
            var serviceRequestId = Guid.NewGuid();

            _serviceRequestRepoMock.Setup(r => r.GetAsync(serviceRequestId)).ReturnsAsync((ServiceRequest)null);
            _serviceRequestRepoMock.Setup(r => r.DeleteAsync(null)).ReturnsAsync(false);
            // Act
            var result = await _serviceRequestService.DeleteAsync(serviceRequestId);
            // Assert
            Assert.False(result);
            Assert.IsType<bool>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfServiceRequestDto_WhenServiceRequestsExist()
        {
            // Arrange
            var serviceRequest1 = new ServiceRequest { Id = Guid.NewGuid(), Description = "Request 1" };
            var serviceRequest2 = new ServiceRequest { Id = Guid.NewGuid(), Description = "Request 2" };
            var serviceRequests = new List<ServiceRequest> { serviceRequest1, serviceRequest2 };
            var serviceRequestDtos = new List<ServiceRequestDto>
            {
                new ServiceRequestDto { Id = serviceRequest1.Id, Description = serviceRequest1.Description },
                new ServiceRequestDto { Id = serviceRequest2.Id, Description = serviceRequest2.Description }
            };
            _serviceRequestRepoMock.Setup(r => r.GetAllAsync(x => x.Requester, x => x.Service)).ReturnsAsync(serviceRequests);
            _mapperMock.Setup(m => m.Map<List<ServiceRequestDto>>(serviceRequests)).Returns(serviceRequestDtos);
            // Act
            var result = await _serviceRequestService.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ServiceRequestDto>>(result);
            Assert.Equal(serviceRequestDtos.Count, result.Count);
        }
        #endregion

    }
}
