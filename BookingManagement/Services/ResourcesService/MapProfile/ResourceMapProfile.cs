using AutoMapper;
using BookingManagement.Domain.Resources;
using BookingManagement.Services.ResourcesService.Dtos;
using Microsoft.OpenApi.Extensions;

namespace BookingManagement.Services.ResourcesService.MapProfile
{
    public class ResourceMapProfile : Profile
    {
        public ResourceMapProfile()
        {
            CreateMap<Resource, ResourceDto>()
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch != null ? s.Branch : null))
                .ForMember(d => d.Department, o => o.MapFrom(s => s.Department != null ? s.Department : null))
                .ForMember(d => d.StatusDescription, o => o.MapFrom(s => s.Status > 0 ? s.Status.GetDisplayName() : null))
                .ForMember(d => d.TypeDescription, o => o.MapFrom(s => s.Type > 0 ? s.Type.GetDisplayName() : null));

            CreateMap<CreateResourceDto, Resource>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Department, o => o.Ignore());

            CreateMap<UpdateResourceDto, Resource>();
        }
    }
}
