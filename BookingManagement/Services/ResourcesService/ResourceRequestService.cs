using AutoMapper;
using BookingManagement.Domain.Resources;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Repositories.ResourcesRepository;
using BookingManagement.Services.ResourcesService.Dtos;

namespace BookingManagement.Services.ResourcesService
{
    public class ResourceRequestService : IResourceRequestService
    {
        private readonly IResourceRequestRepository _resourceRequestRepo;
        private readonly IResourceRepository _resourceRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IMapper _mapper;
        public ResourceRequestService(
            IResourceRequestRepository resourceRequestRepo
            , IResourceRepository resourceRepo
            , IPersonRepository personRepo
            , IMapper mapper
            )
        {
            _resourceRequestRepo = resourceRequestRepo;
            _resourceRepo = resourceRepo;
            _personRepo = personRepo;
            _mapper = mapper;
        }

        public async Task<ResourceRequestDto> CreateAsync(CreateResourceRequestDto input)
        {
            var resource = await _resourceRepo.GetAsync(input.ResourceId);
            var person = await _personRepo.GetAsync(input.RequesterId);

            if (resource is null || person is null)
            {
                return null;
            }

            var resourceRequest = _mapper.Map<ResourceRequest>(input);
            resourceRequest.Resource = resource;
            resourceRequest.Requester = person;

            var createdRequest = await _resourceRequestRepo.AddAsync(resourceRequest);

            return _mapper.Map<ResourceRequestDto>(createdRequest);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var resourceRequest = await _resourceRequestRepo.GetAsync(id);

            if (resourceRequest is null) return false;

            var isDeleted = await _resourceRequestRepo.DeleteAsync(resourceRequest);

            return isDeleted ? true : false;
        }

        public async Task<List<ResourceRequestDto>> GetAllAsync()
        {
            return _mapper.Map<List<ResourceRequestDto>>(
            await _resourceRequestRepo.GetAllAsync(x => x.Requester, x => x.Resource));
        }

        public async Task<ResourceRequestDto> GetAsync(Guid id)
        {
            return _mapper.Map<ResourceRequestDto>(await _resourceRequestRepo.GetAllAsync(x => x.Requester, x => x.Resource));
        }

        public async Task<ResourceRequestDto> UpdateAsync(UpdateResourceRequestDto input)
        {
            var resourceRequest = await _resourceRequestRepo.GetAsync(input.Id);

            if (resourceRequest is null) return null;

            _mapper.Map(input, resourceRequest);

            await _resourceRequestRepo.UpdateAsync(resourceRequest);
            return _mapper.Map<ResourceRequestDto>(resourceRequest);
        }
    }
}
