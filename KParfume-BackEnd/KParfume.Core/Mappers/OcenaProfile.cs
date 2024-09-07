using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class OcenaProfile : Profile
    {
        public OcenaProfile()
        {
            CreateMap<Ocena, OcenaDto>().ReverseMap();
        }

    }
}
