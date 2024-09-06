using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;

namespace KParfume.Core.Mappers
{
    public class VestProfile: Profile
    {
        public VestProfile()
        {
            CreateMap<Vest, VestDto>().ReverseMap();
        }

    }
}
