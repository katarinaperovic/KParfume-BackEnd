using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}