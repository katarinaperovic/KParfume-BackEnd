using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IIzvestajService
    {
        Result<IzvestajDto> Create(IzvestajDto izvestajDto, long fabrikaId);
        Result<List<IzvestajDto>> GetAllForAuthor(long authorId);
    }
}
