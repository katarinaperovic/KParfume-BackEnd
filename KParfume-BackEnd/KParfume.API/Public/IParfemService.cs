using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IParfemService
    {
        Result<ParfemDto> Create(ParfemDto parfemDto);
        ParfemDto Get(long id);
        Result<List<ParfemDto>> GetAll();
        Result<ParfemDto> Update(long id, ParfemDto dto);
        Result<ParfemDto> Remove(long id);
        Result<ParfemDto> UpdateKolicina(long id, int kol);

    }
}
