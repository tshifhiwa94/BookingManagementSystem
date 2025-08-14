using AutoMapper;
using BookingManagement.Domain.Services;
using BookingManagement.Services.ServicesService.Dtos;
using Microsoft.OpenApi.Extensions;

namespace BookingManagement.Services.ServicesService.MapProfile
{
    public class ServiceRequestMapProfile : Profile
    {
        public ServiceRequestMapProfile()
        {

            CreateMap<ServiceRequest, ServiceRequestDto>()
                .ForMember(dest => dest.Requester, opt => opt.MapFrom(src => src.Requester))
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Service))
                .ForMember(dest => dest.ApprovedBy, opt => opt.MapFrom(src => src.ApprovedBy.Name != null ? src.ApprovedBy.Name : null))
                .ForMember(dest => dest.CancelledBy, opt => opt.MapFrom(src => src.CancelledBy.Name != null ? src.CancelledBy.Name : null))
                .ForMember(dest => dest.FulfilledBy, opt => opt.MapFrom(src => src.FulfilledBy.Name != null ? src.FulfilledBy.Name : null))
                .ForMember(dest => dest.RejectedBy, opt => opt.MapFrom(src => src.RejectedBy.Name != null ? src.RejectedBy.Name : null))
                .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => src.Status > 0 ? src.Status.GetDisplayName() : null));

            CreateMap<UpdateServiceRequestDto, ServiceRequest>();
            CreateMap<CreateServiceRequestDto, ServiceRequest>();
        }
    }
}
