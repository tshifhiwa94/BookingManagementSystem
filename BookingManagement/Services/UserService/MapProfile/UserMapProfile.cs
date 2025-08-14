using AutoMapper;
using BookingManagement.Domain.Users;
using BookingManagement.Services.UserService.Dtos;

namespace BookingManagement.Services.UserService.MapProfile
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {

            //  CreateUserDto to User
            CreateMap<CreateUserDto, User>();

            // UpdateUserDto to UserDto
            CreateMap<UpdateUserDto, User>();

            // User to UserDto
            CreateMap<User, UserDto>();

            //UserDto to User
            CreateMap<UserDto, User>();



        }
    }
}
