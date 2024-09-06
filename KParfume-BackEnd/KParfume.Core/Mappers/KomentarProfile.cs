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
    public class KomentarProfile : Profile
    {
        public KomentarProfile()
        {
            CreateMap<Komentar, KomentarDto>().ReverseMap();
        }
    }
}
