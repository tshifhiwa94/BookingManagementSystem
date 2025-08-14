using AutoMapper;
using BookingManagement.Domain.Departments;
using BookingManagement.Repositories.BranchRepository;
using BookingManagement.Repositories.DepartmentsRepository;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Services.DepartmentsService.Dtos;

namespace BookingManagement.Services.DepartmentsService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IBranchRepository _branchRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IMapper _mapper;
        public DepartmentService(
            IDepartmentRepository departmentRepo
            , IBranchRepository branchRepo
            , IPersonRepository personRepo
            , IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _branchRepo = branchRepo;
            _personRepo = personRepo;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            var person = await _personRepo.GetAsync(input.HeadOfDepartmentId);
            var branch = await _branchRepo.GetAsync(input.BranchId);

            if (branch is null) return null;

            var department = _mapper.Map<Department>(input);
            department.Branch = branch;
            department.HeadOfDepartment = person;

            await _departmentRepo.AddAsync(department);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var department = await _departmentRepo.GetAsync(id);
            if (department == null)
            {
                return false;
            }
            var IsItemDeleted = await _departmentRepo.DeleteAsync(department);

            return IsItemDeleted ? true : false;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            return _mapper.Map<List<DepartmentDto>>(await _departmentRepo.GetAllAsync(x => x.Branch, y => y.HeadOfDepartment));
        }

        public async Task<DepartmentDto> GetAsync(Guid id)
        {
            var department = await _departmentRepo.GetAsync(id, x => x.Branch, y => y.HeadOfDepartment);

            if (department is null) return null;

            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> UpdateAsync(DepartmentDto input)
        {
            var deparment = await _departmentRepo.GetAsync((Guid)input.Id);
            if (deparment is null) return null;

            // Use AutoMapper to map to the existing entity
            _mapper.Map(input, deparment);

            return _mapper.Map<DepartmentDto>(await _departmentRepo.UpdateAsync(deparment));
        }
    }
}
