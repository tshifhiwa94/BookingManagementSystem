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

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BranchDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BranchDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BranchDto> UpdateAsync(BranchDto input)
        {
            throw new NotImplementedException();
        }
    }
}
