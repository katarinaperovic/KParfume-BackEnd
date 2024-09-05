using AutoMapper;
using FluentResults;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Services
{
    public class FabrikaService : BaseService<FabrikaDto,Fabrika>,IFabrikaService
    {
        protected readonly IFabrikaRepository _fabrikaRepository;

        public FabrikaService(IFabrikaRepository fabrikaRepository,IMapper mapper) : base(mapper)
        {
            _fabrikaRepository = fabrikaRepository;
        }

        public Result<FabrikaDto> Create(FabrikaDto fabrikaDto)
        {
            try
            {
                Fabrika fabrika = MapToDomain(fabrikaDto);
                fabrika = _fabrikaRepository.Create(fabrika);

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
