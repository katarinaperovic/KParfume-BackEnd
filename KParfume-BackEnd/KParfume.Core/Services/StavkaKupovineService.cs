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
    public class StavkaKupovineService : BaseService<StavkaKupovineDto,StavkaKupovine> ,IStavkaKupovineService
    {
        protected readonly IStavkaKupovineRepository _stavkaKupovineRepository;
        public StavkaKupovineService(IStavkaKupovineRepository stavkaKupovineRepository, IMapper mapper) : base(mapper)
        {
            _stavkaKupovineRepository = stavkaKupovineRepository;
        }

        public Result<StavkaKupovineDto> Create(StavkaKupovineDto stavkaKupovineDto)
        {
            try
            {
                StavkaKupovine stavkaKupovine = MapToDomain(stavkaKupovineDto);
                stavkaKupovine = _stavkaKupovineRepository.Create(stavkaKupovine);

                return Result.Ok<StavkaKupovineDto>(MapToDto(stavkaKupovine));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public StavkaKupovineDto Get(long id)
        {
            StavkaKupovine stavkaKupovine = _stavkaKupovineRepository.Get(id);
            if (stavkaKupovine == null)
            {
                return null;
            }

            return MapToDto(stavkaKupovine);
        }

        public Result<List<StavkaKupovineDto>> GetAll()
        {
            var stavkaKupovinas = _stavkaKupovineRepository.GetAll().ToList();
            return MapToDto(stavkaKupovinas);
        }

        public Result<List<StavkaKupovineDto>> GetAllByKupovinaId(long id)
        {
            var stavkaKupovinas = _stavkaKupovineRepository.GetAllByKupovinaId(id).ToList();
            return MapToDto(stavkaKupovinas);
        }


    }
}
