using FluentResults;
using KParfume.API.DTOs;

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
