using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class ParfemProfile : Profile
    {
        public ParfemProfile()
        {
            CreateMap<Parfem, ParfemDto>().ReverseMap();
        }
    }
}
