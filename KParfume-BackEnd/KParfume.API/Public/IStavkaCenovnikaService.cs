using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IStavkaCenovnikaService
    {
        Result<StavkaCenovnikaDto> Create(StavkaCenovnikaDto stavkaCenovnikaDto);
        StavkaCenovnikaDto Get(long id);
        Result<List<StavkaCenovnikaDto>> GetAll();
        Result<StavkaCenovnikaDto> Remove(long id);
        Result<List<StavkaCenovnikaDto>> GetAllByCenovnikId(long cenovnikId);

    }
}
