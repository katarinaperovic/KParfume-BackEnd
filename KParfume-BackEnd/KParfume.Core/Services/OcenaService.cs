using AutoMapper;
using FluentResults;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Core.Services
{
    public class OcenaService : BaseService<OcenaDto, Ocena>, IOcenaService
    {
        protected readonly IOcenaRepository _ocenaRepository;

        public OcenaService(IOcenaRepository ocenaRepository, IMapper mapper) : base(mapper)
        {
            _ocenaRepository = ocenaRepository;
        }

        public Result<OcenaDto> Create(OcenaDto oDto)
        {
            try
            {
                Ocena ocena = MapToDomain(oDto);
                ocena = _ocenaRepository.Create(ocena);

                return Result.Ok(MapToDto(ocena));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public Result<List<OcenaDto>> GetAll()
        {
            var ocene = _ocenaRepository.GetAll().ToList();
            return MapToDto(ocene);
        }

       



    }
}
