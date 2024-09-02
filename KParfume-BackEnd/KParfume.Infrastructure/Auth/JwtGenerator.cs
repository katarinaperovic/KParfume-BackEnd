using KParfume.API.DTOs;
using KParfume.Core.Domain;
using FluentResults;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using KParfume.Core.Services;
using System.Security.Cryptography;
using System.Text.Json;

namespace KParfume.Infrastructure.Auth
{
    public class JwtGenerator : ITokenGenerator
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private const double dInMinutes = 60 * 24;

        public JwtGenerator()
        {
            string filePath = "../KParfume-BackEnd/Resources/JWT.json";

            string jsonString = File.ReadAllText(filePath);
            JWTDto credentials = JsonSerializer.Deserialize<JWTDto>(jsonString);

            _key = credentials.Key;
            _issuer = credentials.Issuer;
            _audience = credentials.Audience;
        }


        public Result<AuthenticationTokensDto> GenerateAccessToken(User user)
        {
            var authenticationResponse = new AuthenticationTokensDto();

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("id", user.Id.ToString()),
            new("kor_email", user.kor_email),
            new("kor_lozinka", user.kor_lozinka),
            new("kor_uloga", user.GetPrimaryRoleName()),
            new("kor_ime",user.kor_ime),
            new("kor_prezime",user.kor_prezime),
            new("kor_adresa",user.kor_adresa),
            new("kor_grad", user.kor_grad),
            new("kor_pos_br", user.kor_pos_br.ToString()),
            new("kor_drzava", user.kor_drzava),
            new("kor_tel", user.kor_tel),
            new("kor_fab_id", user.kor_fab_id.ToString()),
            new("kor_ime_kompanije", user.kor_ime_kompanije)
        };

            var jwt = CreateToken(claims, dInMinutes);
            authenticationResponse.Id = user.Id;
            authenticationResponse.AccessToken = jwt;

            return authenticationResponse;
        }

        private string CreateToken(IEnumerable<Claim> claims, double expirationTimeInMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(expirationTimeInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
