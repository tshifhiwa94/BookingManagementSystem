using AutoMapper;
using BookingManagement.Domain.Persons;
using BookingManagement.Domain.Users;
using BookingManagement.Services.PersonService.Dtos;
using Microsoft.OpenApi.Extensions;

namespace BookingManagement.Services.PersonService.MapProfile
{
    public class PersonMapProfile : Profile
    {
        public PersonMapProfile()
        {

            // Person to PersonDto
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender > 0 ? src.Gender.GetDisplayName() : null))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id != null ? src.User.Id : null));

            // PersonDto to Person
            CreateMap<CreatePersonDto, Person>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdatePersonDto, Person>();

            CreateMap<CreatePersonDto, User>()
                .ForMember(x => x.Email, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.PasswordHash, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.Phone))
                .ForMember(x => x.Email, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.UserName))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
