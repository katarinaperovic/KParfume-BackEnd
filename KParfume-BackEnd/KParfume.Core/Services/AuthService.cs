using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace KParfume.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFabrikaRepository _fabrikaRepository;
        private readonly ITokenGenerator _tokenGenerator;
        protected readonly IKuponRepository _kuponRepository;

        public AuthService(IUserRepository userRepository,IFabrikaRepository fabrikaRepository, ITokenGenerator tokenGenerator,IKuponRepository kuponRepository)
        {
            _userRepository = userRepository;
            _fabrikaRepository = fabrikaRepository;
            _tokenGenerator = tokenGenerator;
            _kuponRepository = kuponRepository;
        }

        public Result<AuthenticationTokensDto> Login(LoginDto credentials)
        {
            var user = _userRepository.GetActiveByName(credentials.kor_email);
            if (user == null || credentials.kor_lozinka != user.kor_lozinka) return Result.Fail(FailureCode.NotFound);

            return _tokenGenerator.GenerateAccessToken(user);
        }

        public Result<AuthenticationTokensDto> Register(RegisterDto account)
        {
            if (_userRepository.Exists(account.kor_email))
                return Result.Fail(FailureCode.NonUniqueUsername);

            if (account.kor_fab_id.HasValue && !_fabrikaRepository.Exists(account.kor_fab_id.Value))
                return Result.Fail(FailureCode.InvalidArgument).WithError("Specified factory does not exist.");

            try
            {
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
                    account.kor_fab_id, 
                    account.kor_ime_kompanije
                );
                
                User kor=_userRepository.Create(user);

                string kpn_kod = GenerateRandomKuponCode();
                string kpn_opis = "Iskoristite kupon dobrodošlice na prvu kupovinu. Primenjuje se na celokupan iznos prve kupovine.";
                double kpn_popust = 10;
                Boolean kpn_aktivan = true;
                Boolean kpn_pk_valid =true;
               
                Kupon k = new Kupon(kor.Id,kpn_kod,kpn_opis,kpn_popust,kpn_aktivan,kpn_pk_valid);
                _kuponRepository.Create(k);

                return _tokenGenerator.GenerateAccessToken(user);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        private string GenerateRandomKuponCode()
        {
            Random random = new Random();

            // Generate 3 random numbers (100-999)
            string numbers = random.Next(1, 10).ToString();

            // Generate 3 random uppercase letters
            string letters = new string(Enumerable.Range(0, 3)
                                     .Select(x => (char)random.Next('A', 'Z' + 1))
                                     .ToArray());

            // Combine numbers and letters to form the kupon code
            return letters+numbers;
        }


    }
}
