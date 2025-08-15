using AutoMapper;
using BookingManagement.Domain.Addresses;
using BookingManagement.Domain.Branches;
using BookingManagement.Domain.Persons;
using BookingManagement.Repositories;
using BookingManagement.Repositories.BranchRepository;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Services.BranchService.Dtos;

namespace BookingManagement.Services.BranchService
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepo;
        private readonly IAddressRepository _addressRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IMapper _mapper;
        public BranchService(IBranchRepository branchRepo
            , IAddressRepository addressRepo
            , IPersonRepository personRepo
            , IMapper mapper)
        {
            _branchRepo = branchRepo;
            _addressRepo = addressRepo;
            _personRepo = personRepo;
            _mapper = mapper;
        }
        public async Task<BranchDto> CreateAsync(CreateBranchDto input)
        {
            var address = await _addressRepo.GetAsync(input.AddressId);
            var manager = await _personRepo.GetAsync(input.ManagerId);
            var branch = _mapper.Map<Branch>(input);

            branch.Address = _mapper.Map<Address>(address);
            branch.Manager = _mapper.Map<Person>(manager);

            await _branchRepo.AddAsync(branch);

            return _mapper.Map<BranchDto>(branch);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var branch = await _branchRepo.GetAsync(id);

            if (branch is null) return false;

            var isItemDeleted = await _branchRepo.DeleteAsync(branch);

            return isItemDeleted ? true : false;
        }

        public async Task<IEnumerable<BranchDto>> GetAllAsync()
        {
            return _mapper.Map<List<BranchDto>>(await _branchRepo.GetAllAsync(b => b.Manager, b => b.Address));
        }

        public async Task<BranchDto> GetAsync(Guid id)
        {
            return _mapper.Map<BranchDto>(await _branchRepo.GetAsync(id, b => b.Manager, b => b.Address));
        }

        public async Task<BranchDto> UpdateAsync(UpdateBranchDto input)
        {
            var branch = await _branchRepo.GetAsync(input.Id);
            var address = await _addressRepo.GetAsync(input.AddressId);
            var manager = await _personRepo.GetAsync(input.ManagerId);

            if (branch is null || address is null || manager is null) return null;

            // Use AutoMapper to map to the existing entity
            _mapper.Map(input, branch);

            if (branch.Address != address)
            {
                branch.Address = address;
            }
            if (branch.Manager != manager)
            {
                branch.Manager = manager;
            }

            return _mapper.Map<BranchDto>(await _branchRepo.UpdateAsync(branch));
        }
    }
}
