using AutoMapper;
using BookingManagement.Domain.Branches;
using BookingManagement.Services.BranchService.Dtos;

namespace BookingManagement.Services.BranchService.MapProfile
{
    public class BranchMapProfile : Profile
    {
        public BranchMapProfile()
        {
            CreateMap<Branch, BranchDto>()
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address != null ? s.Address : null))
                .ForMember(d => d.Manager, o => o.MapFrom(s => s.Manager != null ? s.Manager : null));

            CreateMap<CreateBranchDto, Branch>()
                .ForMember(d => d.Id, o => o.Ignore());

        }
    }
}
