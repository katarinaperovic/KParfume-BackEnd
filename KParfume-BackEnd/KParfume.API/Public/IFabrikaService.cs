using FluentResults;
using KParfume.API.DTOs;

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
