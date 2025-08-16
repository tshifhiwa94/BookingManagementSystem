using AutoMapper;
using BookingManagement.Domain.Resources;
using BookingManagement.Services.ResourcesService.Dtos;
using Microsoft.OpenApi.Extensions;

namespace BookingManagement.Services.ResourcesService.MapProfile
{
    public class ResourceRequestMapProfile : Profile
    {
        public ResourceRequestMapProfile()
        {
            // Mapping from ResourceRequest to ResourceRequestDto
            CreateMap<ResourceRequest, ResourceRequestDto>()
                .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => src.Status > 0 ? src.Status.GetDisplayName() : null))
                .ForMember(dest => dest.ApprovedBy, opt => opt.MapFrom(src => (!string.IsNullOrEmpty(src.Requester.Surname) || !string.IsNullOrEmpty(src.Requester.Name)) ? $"{src.Requester.Name} {src.Requester.Surname}" : string.Empty))
                .ForMember(dest => dest.CancelledBy, opt => opt.MapFrom(src => (!string.IsNullOrEmpty(src.Requester.Surname) || !string.IsNullOrEmpty(src.Requester.Name)) ? $"{src.Requester.Name} {src.Requester.Surname}" : string.Empty))
                .ForMember(dest => dest.RejectedBy, opt => opt.MapFrom(src => (!string.IsNullOrEmpty(src.Requester.Surname) || !string.IsNullOrEmpty(src.Requester.Name)) ? $"{src.Requester.Name} {src.Requester.Surname}" : string.Empty))
                .ForMember(dest => dest.ReturnedBy, opt => opt.MapFrom(src => (!string.IsNullOrEmpty(src.Requester.Surname) || !string.IsNullOrEmpty(src.Requester.Name)) ? $"{src.Requester.Name} {src.Requester.Surname}" : string.Empty));

            // Mapping from CreateResourceRequestDto to ResourceRequest
            CreateMap<CreateResourceRequestDto, ResourceRequest>();

            // Mapping from UpdateResourceRequest to ResourceRequest
            CreateMap<UpdateResourceRequestDto, ResourceRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id to prevent overwriting
                .ForMember(dest => dest.Resource, opt => opt.Ignore()) // Ignore Resource to prevent overwriting
                .ForMember(dest => dest.Requester, opt => opt.Ignore()); // Ignore Requester to prevent overwriting
        }
    }
}
