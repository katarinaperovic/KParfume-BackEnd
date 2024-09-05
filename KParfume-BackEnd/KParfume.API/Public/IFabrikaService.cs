using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IFabrikaService
    {
        Result<FabrikaDto> Create(FabrikaDto fabrikaDto);
        FabrikaDto Get(long id);
        Result<List<FabrikaDto>> GetAll();
        Result<FabrikaDto> Remove(long id);
    }
}
