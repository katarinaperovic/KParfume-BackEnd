using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class FavoritProfile : Profile
    {
        public FavoritProfile()
        {
            CreateMap<Favorit, FavoritDto>().ReverseMap();
        }

    }
}
