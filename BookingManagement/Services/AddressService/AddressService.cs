using AutoMapper;
using BookingManagement.Domain.Addresses;
using BookingManagement.Repositories;
using BookingManagement.Services.AddressService.Dtos;

namespace BookingManagement.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository addressRepo,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<AddressDto> CreateAsync(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressRepo.AddAsync(address);

            return _mapper.Map<AddressDto>(address);
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AddressDto>>(await _addressRepo.GetAllAsync());
        }

        public async Task<AddressDto> GetAsync(Guid id)
        {
            var address = await _addressRepo.GetAsync(id);
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with ID {id} not found.");
            }

            return _mapper.Map<AddressDto>(address);
        }

        public async Task<AddressDto> UpdateAsync(Guid id, UpdateAddressDto addressDto)
        {
            var existingAddress = await _addressRepo.GetAsync(id);
            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with ID {id} not found.");
            }

            // Use AutoMapper to map to the existing entity
            _mapper.Map(addressDto, existingAddress);

            var updatedAddress = await _addressRepo.UpdateAsync(existingAddress);
            return _mapper.Map<AddressDto>(updatedAddress);
        }



        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingAddress = await _addressRepo.GetAsync(id);
            if (existingAddress is null)
            {
                return false; // Address not found, return false
            }

            var isDeleted = await _addressRepo.DeleteAsync(existingAddress);
            if (!isDeleted)
            {
                return false; // If the deletion operation failed, return false
            }

            return true; // Address deleted successfully
        }
    }
}
