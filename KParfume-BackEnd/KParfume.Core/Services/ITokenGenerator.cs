using KParfume.API.DTOs;
using KParfume.Core.Domain;
using FluentResults;

namespace KParfume.Core.Services
{
    public interface ITokenGenerator
    {
        Result<AuthenticationTokensDto> GenerateAccessToken(User user);
    }
}
