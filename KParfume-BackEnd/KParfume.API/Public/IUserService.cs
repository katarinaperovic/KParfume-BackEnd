using KParfume.API.DTOs;
using FluentResults;

namespace KParfume.API.Public
{
    public interface IUserService
    {
        Result<UserDto> GetById(long userId);
        Result<List<UserDto>> GetAll();
    }
}
