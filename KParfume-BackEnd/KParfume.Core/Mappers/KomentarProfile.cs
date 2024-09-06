using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class KomentarProfile : Profile
    {
        public KomentarProfile()
        {
            CreateMap<Komentar, KomentarDto>().ReverseMap();
        }
    }
}
