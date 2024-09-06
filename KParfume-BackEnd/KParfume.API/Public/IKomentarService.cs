using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IKomentarService
    {
        Result<KomentarDto> Create(KomentarDto komentarDto);
        KomentarDto Get(long id);
        Result<List<KomentarDto>> GetAll();
        Result<KomentarDto> Remove(long id);

    }
}
