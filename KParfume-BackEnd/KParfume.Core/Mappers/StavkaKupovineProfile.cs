﻿using AutoMapper;
using KParfume.API.DTOs;
using KParfume.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Mappers
{
    public class StavkaKupovineProfile : Profile
    {
        public StavkaKupovineProfile()
        {
            CreateMap<StavkaKupovine, StavkaKupovineDto>().ReverseMap();
        }
    }
}
