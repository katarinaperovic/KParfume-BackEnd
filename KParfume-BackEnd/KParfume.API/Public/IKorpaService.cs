using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IKorpaService
    {
        Result<KorpaDto> Create(KorpaDto korpaDto);
        KorpaDto Get(long id);
        Result<List<KorpaDto>> GetAll();
        Result<KorpaDto> Remove(long id);
        Result<KorpaDto> KorpaPrazna(long id);
        Result<KorpaDto> KorpaNijePrazna(long id);

    }
}
