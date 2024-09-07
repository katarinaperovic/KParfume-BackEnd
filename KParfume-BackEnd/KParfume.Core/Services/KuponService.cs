using AutoMapper;
using FluentResults;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Core.Services
{
    public class KuponService : BaseService<KuponDto, Kupon>, IKuponService
    {
        protected readonly IKuponRepository _kuponRepository;

        public KuponService(IKuponRepository kuponRepository, IMapper mapper) : base(mapper)
        {
            _kuponRepository = kuponRepository;
        }

        public Result<KuponDto> Create(KuponDto kDto)
        {
            try
            {
                Kupon kupon = MapToDomain(kDto);
                kupon = _kuponRepository.Create(kupon);

                return Result.Ok(MapToDto(kupon));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public KuponDto Get(long id)
        {
            Kupon kupon = _kuponRepository.Get(id);
            if (kupon == null)
            {
                return null;
            }

            return MapToDto(kupon);
        }

        public Result<List<KuponDto>> GetAll()
        {
            var kuponi = _kuponRepository.GetAll().ToList();
            return MapToDto(kuponi);
        }

        public Result<KuponDto> Remove(long id)
        {
            try
            {
                Kupon kupon = _kuponRepository.Get(id);
                if (kupon == null)
                {
                    return Result.Fail(FailureCode.NotFound);
                }

                _kuponRepository.Remove(kupon);
                return Result.Ok(MapToDto(kupon));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }



    }
}
