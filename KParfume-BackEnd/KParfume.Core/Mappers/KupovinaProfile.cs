using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Mappers
{
    public class KupovinaProfile : Profile
    {
        public KupovinaProfile()
        {
            CreateMap<Kupovina, KupovinaDto>().ReverseMap();
        }
    }
}
