using AutoMapper;
using BookingManagement.Domain.Addresses;
using BookingManagement.Services.AddressService.Dtos;

namespace BookingManagement.Services.AddressService.Mapping
{
    public class AddresssMapProfile : Profile
    {
        public AddresssMapProfile()
        {
            // For example: CreateMap<Source, Destination>();

            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>()
                .ForMember(x => x.Id, y => y.Ignore());
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<UpdateAddressDto, AddressDto>();

        }

    }

}
