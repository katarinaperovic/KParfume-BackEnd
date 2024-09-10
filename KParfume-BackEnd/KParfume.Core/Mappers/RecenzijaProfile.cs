using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class RecenzijaProfile : Profile
    {
        public RecenzijaProfile()
        {
            CreateMap<Recenzija, RecenzijaDto>().ReverseMap();
        }

    }
}
