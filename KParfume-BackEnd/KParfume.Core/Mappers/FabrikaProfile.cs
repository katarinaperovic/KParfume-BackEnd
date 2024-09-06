using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class FabrikaProfile : Profile
    {
        public FabrikaProfile()
        {
            CreateMap<Fabrika, FabrikaDto>().ReverseMap();
        }

    }
}
