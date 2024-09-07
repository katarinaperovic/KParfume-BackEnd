using AutoMapper;
using FluentResults;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Core.Services
{
    public class KomentarService : BaseService<KomentarDto,Komentar>,IKomentarService
    {
        protected readonly IKomentarRepository _komentarRepository;

        public KomentarService(IKomentarRepository komentarRepository, IMapper mapper) : base(mapper)
        {
            _komentarRepository = komentarRepository;
        }

        public Result<KomentarDto> Create(KomentarDto komentarDto)
        {
            try
            {
                Komentar komentar = MapToDomain(komentarDto);
                komentar = _komentarRepository.Create(komentar);

                return Result.Ok(MapToDto(komentar));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public KomentarDto Get(long id)
        {
            Komentar komentar = _komentarRepository.Get(id);
            if (komentar == null)
            {
                return null;
            }

            return MapToDto(komentar);
        }

        public Result<List<KomentarDto>> GetAll()
        {
            var komentars = _komentarRepository.GetAll().ToList();
            return MapToDto(komentars);
        }
        public Result<List<KomentarDto>> GetCommentsByVestId(long vestId)
        {
            var komentars = _komentarRepository.GetByVestId(vestId).ToList();
            return MapToDto(komentars);
        }
        public Result<KomentarDto> Remove(long id)
        {
            try
            {
                Komentar komentar = _komentarRepository.Get(id);
                if (komentar == null)
                {
                    return Result.Fail(FailureCode.NotFound);
                }

                _komentarRepository.Remove(komentar);
                return Result.Ok(MapToDto(komentar));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }   
    }
}
