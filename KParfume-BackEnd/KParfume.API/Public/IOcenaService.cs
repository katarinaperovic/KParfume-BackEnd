using FluentResults;
using KParfume.API.DTOs;

namespace KParfume.API.Public
{
    public interface IOcenaService
    {
        Result<OcenaDto> Create(OcenaDto ocenaDto);
        Result<List<OcenaDto>> GetAll();

    }
}
