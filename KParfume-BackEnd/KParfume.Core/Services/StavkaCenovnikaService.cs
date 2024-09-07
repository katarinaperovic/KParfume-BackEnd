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
    public class StavkaCenovnikaService : BaseService<StavkaCenovnikaDto,StavkaCenovnika> ,IStavkaCenovnikaService
    {
        protected readonly IStavkaCenovnikaRepository _stavkaCenovnikaRepository;

        public StavkaCenovnikaService(IStavkaCenovnikaRepository stavkaCenovnikaRepository, IMapper mapper) : base(mapper)
        {
            _stavkaCenovnikaRepository = stavkaCenovnikaRepository;
        }

        public Result<StavkaCenovnikaDto> Create(StavkaCenovnikaDto stavkaCenovnikaDto)
        {
            try
            {
                StavkaCenovnika stavkaCenovnika = MapToDomain(stavkaCenovnikaDto);
                stavkaCenovnika = _stavkaCenovnikaRepository.Create(stavkaCenovnika);
                
                return Result.Ok<StavkaCenovnikaDto>(MapToDto(stavkaCenovnika));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public StavkaCenovnikaDto Get(long id)
        {
            StavkaCenovnika stavkaCenovnika = _stavkaCenovnikaRepository.Get(id);
            if (stavkaCenovnika == null)
            {
                return null;
            }

            return MapToDto(stavkaCenovnika);
        }

        public Result<List<StavkaCenovnikaDto>> GetAll()
        {
            var stavkaCenovnikas = _stavkaCenovnikaRepository.GetAll().ToList();
            return MapToDto(stavkaCenovnikas);
        }

        public Result<StavkaCenovnikaDto> Remove(long id)
        {
            StavkaCenovnika stavkaCenovnika = _stavkaCenovnikaRepository.Get(id);
            if (stavkaCenovnika == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }

            _stavkaCenovnikaRepository.Remove(stavkaCenovnika);
            return Result.Ok<StavkaCenovnikaDto>(MapToDto(stavkaCenovnika));
        }

        public Result<List<StavkaCenovnikaDto>> GetAllByCenovnikId(long cenovnikId)
        {
            var stavkaCenovnikas = _stavkaCenovnikaRepository.GetAllByCenovnikId(cenovnikId).ToList();
            return MapToDto(stavkaCenovnikas);
        }


    }
}
