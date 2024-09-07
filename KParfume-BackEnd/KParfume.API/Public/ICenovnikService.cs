using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface ICenovnikService
    {
        Result<CenovnikDto> Create(CenovnikDto dto);
        CenovnikDto Get(long id);
        CenovnikDto GetByFabrikaId(long id);
        Result<List<CenovnikDto>> GetAll();
        Result<CenovnikDto> Remove(long id);

    }
}
