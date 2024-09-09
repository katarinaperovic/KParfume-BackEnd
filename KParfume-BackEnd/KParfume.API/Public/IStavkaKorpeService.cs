using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IStavkaKorpeService
    {
        public Result<StavkaKorpeDto> Create(StavkaKorpeDto stavkaKorpeDto);
        public StavkaKorpeDto Get(long id);
        public Result<List<StavkaKorpeDto>> GetAll();
        public Result<List<StavkaKorpeDto>> GetAllByKorpaId(long id);
        public Result<StavkaKorpeDto> Remove(long id);
        public Result<List<StavkaKorpeDto>> RemoveAllByUserId(long userId);
        public Result<StavkaKorpeDto> InkrementKolicina(long id);
        public Result<StavkaKorpeDto> DekrementKolicina(long id);

    }
}
