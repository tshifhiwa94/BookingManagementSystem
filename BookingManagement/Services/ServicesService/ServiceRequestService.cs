using AutoMapper;
using BookingManagement.Domain.Services;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Repositories.ServicesRepository;
using BookingManagement.Services.ServicesService.Dtos;

namespace BookingManagement.Services.ServicesService
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _serviceRequestRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IServiceRepository _serviceRepo;
        private IMapper _mapper;
        public ServiceRequestService(
              IServiceRequestRepository serviceRequestRepo
            , IPersonRepository personRepo
            , IServiceRepository serviceRepo
            , IMapper mapper)
        {
            _serviceRequestRepo = serviceRequestRepo;
            _personRepo = personRepo;
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }
        public async Task<ServiceRequestDto> CreateAsync(CreateServiceRequestDto input)
        {
            var service = await _serviceRepo.GetAsync(input.ServiceId);
            var requester = await _personRepo.GetAsync(input.RequesterId);
            if (service is null || requester is null)
            {
                return null;
            }

            var serviceRequest = _mapper.Map<ServiceRequest>(input);
            // ServiceRequest has properties for Service and Requester
            serviceRequest.Service = service;
            serviceRequest.Requester = requester;

            var createdServiceRequest = await _serviceRequestRepo.AddAsync(serviceRequest);
            return _mapper.Map<ServiceRequestDto>(createdServiceRequest);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var serviceRequest = await _serviceRequestRepo.GetAsync(id);
            if (serviceRequest is null)
            {
                return false;
            }
            var isItemDeleted = await _serviceRequestRepo.DeleteAsync(serviceRequest);
            return isItemDeleted ? true : false;
        }

        public async Task<List<ServiceRequestDto>> GetAllAsync()
        {
            var serviceRequests = await _serviceRequestRepo.GetAllAsync(x => x.Requester, x => x.Service);
            return _mapper.Map<List<ServiceRequestDto>>(serviceRequests);
        }

        public Task<ServiceRequestDto> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
            var serviceRequest = _serviceRequestRepo.GetAsync(id, x => x.Requester, x => x.Service);
            return _mapper.Map<Task<ServiceRequestDto>>(serviceRequest);
        }

        public async Task<ServiceRequestDto> UpdateAsync(UpdateServiceRequestDto input)
        {
            var serviceRequest = await _serviceRequestRepo.GetAsync(input.Id);
            if (serviceRequest is null)
            {
                return null;
            }
            // Map the input to the existing service request
            _mapper.Map(input, serviceRequest);
            // Update the service request in the repository
            return _mapper.Map<ServiceRequestDto>(await _serviceRequestRepo.UpdateAsync(serviceRequest));
        }
    }
}
