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
    public class CenovnikService : BaseService<CenovnikDto,Cenovnik> ,ICenovnikService
    {
        protected readonly ICenovnikRepository _cenovnikRepository;

        public CenovnikService(ICenovnikRepository cenovnikRepository, IMapper mapper) : base(mapper) 
        {
            _cenovnikRepository = cenovnikRepository;
        }

        public Result<CenovnikDto> Create(CenovnikDto dto)
        {
            try
            {
                Cenovnik cenovnik = MapToDomain(dto);
                cenovnik = _cenovnikRepository.Create(cenovnik);

                return Result.Ok<CenovnikDto>(MapToDto(cenovnik));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public CenovnikDto Get(long id)
        {
            Cenovnik cenovnik = _cenovnikRepository.Get(id);
            if (cenovnik == null)
            {
                return null;
            }

            return MapToDto(cenovnik);
        }

        public CenovnikDto GetByFabrikaId(long id)
        {
            Cenovnik cenovnik = _cenovnikRepository.GetByFabrikaId(id);
            if (cenovnik == null)
            {
                return null;
            }

            return MapToDto(cenovnik);
        }

        public Result<List<CenovnikDto>> GetAll()
        {
            var cenovnici = _cenovnikRepository.GetAll().ToList();
            return MapToDto(cenovnici);
        }

        public Result<CenovnikDto> Remove(long id)
        {
            Cenovnik cenovnik = _cenovnikRepository.Get(id);
            if (cenovnik == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }

            _cenovnikRepository.Remove(cenovnik);
            return Result.Ok(MapToDto(cenovnik));
        }



    }
}
