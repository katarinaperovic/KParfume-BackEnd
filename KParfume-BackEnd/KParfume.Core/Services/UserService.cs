using AutoMapper;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace KParfume.Core.Services
{
    public class UserService : CrudService<UserDto, User>, IUserService
    {
        private readonly IUserRepository UserRepository;

        public UserService(ICrudRepository<User> crudRepository, IMapper mapper, IUserRepository userRepository) : base(crudRepository,mapper)
        {
            UserRepository = userRepository;
        }
        public Result<UserDto> GetById(long userId)
        {
            User user = UserRepository.GetById(userId);
            return MapToDto(user);
        }

        public UserDto Get(long id)
        {
            User u = UserRepository.Get(id);
            if (u == null)
            {
                return null;
            }

            return MapToDto(u);
        }
        public Result<List<UserDto>> GetAll()
        {
            var users = UserRepository.GetAll().ToList();
            return MapToDto(users);
        }

        public UserRole MapToUserRole(UserRoleDto dto)
        {
            switch (dto)
            {
                case UserRoleDto.ADMINISTRATOR:
                    return UserRole.ADMINISTRATOR;
                case UserRoleDto.MENADZER:
                    return UserRole.MENADZER;
                case UserRoleDto.RADNIK:
                    return UserRole.RADNIK;
                case UserRoleDto.KUPAC:
                    return UserRole.KUPAC;
                default:
                    throw new ArgumentException("Invalid UserRoleDto value");
            }
        }

        public Result<UserDto> Update(long id, UserDto dto)
        {
            User u = UserRepository.Get(id);
            if (u == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }
            try
            {
                u.Update(dto.kor_email,dto.kor_lozinka, MapToUserRole(dto.kor_uloga), dto.kor_ime,dto.kor_prezime,dto.kor_adresa,dto.kor_grad,dto.kor_pos_br,dto.kor_drzava,dto.kor_tel,dto.kor_fab_id,dto.kor_ime_kompanije);
                UserRepository.Save();
                return MapToDto(u);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }


    }
}
