using KParfume.API.DTOs;
using FluentResults;

namespace KParfume.API.Public
{
    public interface IUserService
    {
        Result<UserDto> GetById(long userId);
        UserDto Get(long id);
        Result<UserDto> Update(long id, UserDto dto);
        Result<List<UserDto>> GetAll();
    }
}
