using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IStavkaKupovineService
    {
        Result<StavkaKupovineDto> Create(StavkaKupovineDto stavkaKupovineDto);
        StavkaKupovineDto Get(long id);
        Result<List<StavkaKupovineDto>> GetAll();
        Result<List<StavkaKupovineDto>> GetAllByKupovinaId(long id);
    }
}
