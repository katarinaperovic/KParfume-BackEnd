using KParfume.API.DTOs;
using FluentResults;

namespace KParfume.API.Public
{
    public interface IAuthService
    {
        Result<AuthenticationTokensDto> Login(LoginDto credentials);
        Result<AuthenticationTokensDto> Register(RegisterDto account);
    }
}
