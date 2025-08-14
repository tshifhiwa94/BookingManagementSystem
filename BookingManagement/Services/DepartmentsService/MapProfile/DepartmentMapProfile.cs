using AutoMapper;
using BookingManagement.Domain.Departments;
using BookingManagement.Services.DepartmentsService.Dtos;

namespace BookingManagement.Services.DepartmentsService.MapProfile
{
    public class DepartmentMapProfile : Profile
    {
        public DepartmentMapProfile()
        {
            // Map Department to DepartmentDto
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.HeadOfDepartment,
                opt => opt.MapFrom(src => src.HeadOfDepartment.Id != null ? src.HeadOfDepartment : null))
                .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.Id != null ? src.Branch : null));

            //Map DepartmentDto to Department
            CreateMap<CreateDepartmentDto, Department>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            ;
        }
    }
}
