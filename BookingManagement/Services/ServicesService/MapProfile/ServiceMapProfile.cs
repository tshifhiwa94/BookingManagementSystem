using AutoMapper;
using BookingManagement.Domain.Services;
using BookingManagement.Services.ServicesService.Dtos;
using Microsoft.OpenApi.Extensions;

namespace BookingManagement.Services.ServicesService.MapProfile
{
    public class ServiceMapProfile : Profile
    {
        public ServiceMapProfile()
        {

            CreateMap<Service, ServiceDto>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(d => d.StatusDescription, o => o.MapFrom(s => s.Status > 0 ? s.Status.GetDisplayName() : null))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category > 0 ? s.Category.GetDisplayName() : null))
                .ForMember(d => d.DeliveryMethodName, o => o.MapFrom(s => s.DeliveryMethod > 0 ? s.DeliveryMethod.GetDisplayName() : null));

            CreateMap<CreateServiceDto, Service>();

            CreateMap<UpdateServiceDto, Service>();
        }
    }

}
