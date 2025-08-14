using AutoMapper;
using BookingManagement.Domain.Services;
using BookingManagement.Repositories.DepartmentsRepository;
using BookingManagement.Repositories.ServicesRepository;
using BookingManagement.Services.ServicesService.Dtos;

namespace BookingManagement.Services.ServicesService
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IMapper _mapper;
        public ServiceService(
            IServiceRepository serviceRepo
            , IDepartmentRepository departmentRepo
            , IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }
        public async Task<ServiceDto> CreateAsync(CreateServiceDto input)
        {
            var department = await _departmentRepo.GetAsync(input.DepartmentId);

            if (department == null) { return null; }

            var service = _mapper.Map<Service>(input);

            // map department property to service
            service.Department = department;

            return _mapper.Map<ServiceDto>(await _serviceRepo.AddAsync(service));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var service = await _serviceRepo.GetAsync(id);
            if (service == null) { return false; }

            var isDeletedItem = await _serviceRepo.DeleteAsync(service);
            return isDeletedItem ? true : false;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllAsync()
        {
            var services = await _serviceRepo.GetAllAsync(s => s.Department);
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto> GetAsync(Guid id)
        {
            var service = await _serviceRepo.GetAsync(id, s => s.Department);
            if (service == null) { return null; }

            return _mapper.Map<ServiceDto>(service);
        }

        public async Task<ServiceDto> UpdateAsync(UpdateServiceDto input)
        {
            var service = await _serviceRepo.GetAsync(input.Id, s => s.Department);

            if (service == null) { return null; }

            _mapper.Map(input, service);

            return _mapper.Map<ServiceDto>(await _serviceRepo.UpdateAsync(service));
        }
    }
}
