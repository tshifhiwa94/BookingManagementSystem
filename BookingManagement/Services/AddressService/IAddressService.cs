using BookingManagement.Services.AddressService.Dtos;

namespace BookingManagement.Services.AddressService
{
    public interface IAddressService
    {
        Task<AddressDto> GetAsync(Guid id);
        Task<IEnumerable<AddressDto>> GetAllAsync();
        Task<AddressDto> CreateAsync(AddressDto addressDto);
        Task<AddressDto> UpdateAsync(Guid id, UpdateAddressDto addressDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
