using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IVestService
    {
        Result<VestDto> Create(VestDto vestDto);
        VestDto Get(long id);
        Result<List<VestDto>> GetAll();
        Result<VestDto> Remove(long id);
        Result<VestDto> UpdateVest(long id, VestDto dto);

    }
}
