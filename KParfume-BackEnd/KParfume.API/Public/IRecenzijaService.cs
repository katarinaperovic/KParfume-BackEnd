using FluentResults;
using KParfume.API.DTOs;

namespace KParfume.API.Public
{
    public interface IRecenzijaService
    {
        Result<RecenzijaDto> Create(RecenzijaDto recenzijaDto);
        Result<RecenzijaDto> Update(long id, RecenzijaDto dto);
        Result<List<RecenzijaDto>> GetRecenzijeByFabrikaId(long fabrikaId);

    }
}
