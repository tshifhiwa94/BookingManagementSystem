using AutoMapper;
using BookingManagement.Domain.Resources;
using BookingManagement.Repositories.BranchRepository;
using BookingManagement.Repositories.DepartmentsRepository;
using BookingManagement.Repositories.ResourcesRepository;
using BookingManagement.Services.ResourcesService.Dtos;

namespace BookingManagement.Services.ResourcesService
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IBranchRepository _branchRepo;
        private readonly IMapper _mapper;
        public ResourceService(
            IResourceRepository resourceRepo
            , IDepartmentRepository departmentRepo
            , IBranchRepository branchRepo
            , IMapper mapper)
        {
            _resourceRepo = resourceRepo;
            _departmentRepo = departmentRepo;
            _branchRepo = branchRepo;
            _mapper = mapper;
        }
        public async Task<ResourceDto> CreateAsync(CreateResourceDto input)
        {
            var branch = await _branchRepo.GetAsync(input.BranchId);
            if (branch is null) return null;

            var department = await _departmentRepo.GetAsync((Guid)input.DepartmentId);

            var resource = _mapper.Map<Resource>(input);
            resource.Branch = branch;
            resource.Department = department;

            await _resourceRepo.AddAsync(resource);
            return _mapper.Map<ResourceDto>(resource);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var resource = await _resourceRepo.GetAsync(id);

            if (resource is null) return false;

            var isItemDeleted = await _resourceRepo.DeleteAsync(resource);
            return isItemDeleted ? true : false;
        }

        public async Task<IEnumerable<ResourceDto>> GetAllAsync()
        {
            return _mapper.Map<List<ResourceDto>>(await _resourceRepo.GetAllAsync(x => x.Department, y => y.Branch));
        }

        public async Task<ResourceDto> GetAsync(Guid id)
        {
            if (await _resourceRepo.GetAsync(id) is null) return null;

            return _mapper.Map<ResourceDto>(await _resourceRepo.GetAsync(id, x => x.Department, y => y.Branch));
        }

        public async Task<ResourceDto> UpdateAsync(UpdateResourceDto input)
        {
            var resource = await _resourceRepo.GetAsync(input.Id);
            if (resource is null) return null;

            _mapper.Map(input, resource);

            await _resourceRepo.UpdateAsync(resource);
            return _mapper.Map<ResourceDto>(resource);
        }
    }
}
