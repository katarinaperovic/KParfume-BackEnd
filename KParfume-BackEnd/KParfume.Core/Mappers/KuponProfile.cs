using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class KuponProfile : Profile
    {
        public KuponProfile()
        {
            CreateMap<Kupon, KuponDto>().ReverseMap();
        }

    }
}
