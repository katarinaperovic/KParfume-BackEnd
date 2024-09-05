using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFabrikaRepository _fabrikaRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthService(IUserRepository userRepository,IFabrikaRepository fabrikaRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _fabrikaRepository = fabrikaRepository;
            _tokenGenerator = tokenGenerator;
        }

        public Result<AuthenticationTokensDto> Login(LoginDto credentials)
        {
            var user = _userRepository.GetActiveByName(credentials.kor_email);
            if (user == null || credentials.kor_lozinka != user.kor_lozinka) return Result.Fail(FailureCode.NotFound);

            return _tokenGenerator.GenerateAccessToken(user);
        }

        /*        public Result<AuthenticationTokensDto> Register(RegisterDto account)
                {
        //          if (account.Role == UserRoleDto.Administrator) return Result.Fail(FailureCode.InvalidArgument);
                    if (_userRepository.Exists(account.kor_email)) return Result.Fail(FailureCode.NonUniqueUsername);
                    //UserRole role = UserRole.Client; // UserRole role = account.Role == UserRoleDto.Manager? UserRole.Manager : UserRole.Client;


                    try
                    {
                        var user = _userRepository.Create(new User(account.kor_email, account.kor_lozinka, (UserRole)account.kor_uloga, account.kor_ime, account.kor_prezime, account.kor_adresa, account.kor_grad, account.kor_pos_br, account.kor_drzava, account.kor_tel, account.kor_fab_id, account.kor_ime_kompanije));

                        return _tokenGenerator.GenerateAccessToken(user);
                    }
                    catch (ArgumentException e)
                    {
                        return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
                    }
                }*/

        public Result<AuthenticationTokensDto> Register(RegisterDto account)
        {
            // Check if the email already exists in the system
            if (_userRepository.Exists(account.kor_email))
                return Result.Fail(FailureCode.NonUniqueUsername);

            // Check if kor_fab_id is provided and valid only if it is not null
            if (account.kor_fab_id.HasValue && !_fabrikaRepository.Exists(account.kor_fab_id.Value))
                return Result.Fail(FailureCode.InvalidArgument).WithError("Specified factory does not exist.");

            try
            {
                // Create a new user with the information provided, including an optional kor_fab_id
                var user = new User(
                    account.kor_email,
                    account.kor_lozinka,
                    (UserRole)account.kor_uloga,
                    account.kor_ime,
                    account.kor_prezime,
                    account.kor_adresa,
                    account.kor_grad,
                    account.kor_pos_br,
                    account.kor_drzava,
                    account.kor_tel,
                    account.kor_fab_id,  // This may be null if not provided
                    account.kor_ime_kompanije
                );

                _userRepository.Create(user);
                return _tokenGenerator.GenerateAccessToken(user);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

    }
}
