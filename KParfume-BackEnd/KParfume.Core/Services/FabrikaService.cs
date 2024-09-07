using AutoMapper;
using FluentResults;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Core.Services
{
    public class FabrikaService : BaseService<FabrikaDto,Fabrika>,IFabrikaService
    {
        protected readonly IFabrikaRepository _fabrikaRepository;
        protected readonly ICenovnikRepository _cenovnikRepository;

        public FabrikaService(IFabrikaRepository fabrikaRepository,ICenovnikRepository cenovnikRepository,IMapper mapper) : base(mapper)
        {
            _fabrikaRepository = fabrikaRepository;
            _cenovnikRepository = cenovnikRepository;
        }

        public Result<FabrikaDto> Create(FabrikaDto fabrikaDto)
        {
            try
            {
                Fabrika fabrika = MapToDomain(fabrikaDto);
                fabrika = _fabrikaRepository.Create(fabrika);

                DateOnly cenovnikDate = DateOnly.FromDateTime(DateTime.Now);
                Cenovnik cenovnik = new Cenovnik(cenovnikDate,fabrika.Id);
                _cenovnikRepository.Create(cenovnik);

                return Result.Ok(MapToDto(fabrika));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public FabrikaDto Get(long id)
        {
            Fabrika fabrika = _fabrikaRepository.Get(id);
            if (fabrika == null)
            {
                return null;
            }

            return MapToDto(fabrika);  
        }

        public Result<List<FabrikaDto>> GetAll()
        {
            var fabrikas = _fabrikaRepository.GetAll().ToList();
            return MapToDto(fabrikas);
        }

        public Result<FabrikaDto> Remove(long id)
        {
            try
            {
                Fabrika fabrika = _fabrikaRepository.Get(id);
                if (fabrika == null)
                {
                    return Result.Fail(FailureCode.NotFound).WithError("Fabrika not found");
                }

                _fabrikaRepository.Remove(fabrika);
                return Result.Ok(MapToDto(fabrika));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

    }
}
