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
    public class ParfemService : BaseService<ParfemDto, Parfem>, IParfemService
    {
        protected readonly IParfemRepository _parfemRepository;

        public ParfemService(IParfemRepository parfemRepository, IMapper mapper) : base(mapper)
        {
            _parfemRepository = parfemRepository;
        }

        public Result<ParfemDto> Create(ParfemDto parfemDto)
        {
            try
            {
                parfemDto.par_obrisan = false;
                if (parfemDto.par_kolicina == 0)
                {
                    parfemDto.par_dostupan = false;
                }
                else { parfemDto.par_dostupan = true; }

                Parfem parfem = MapToDomain(parfemDto);
                parfem = _parfemRepository.Create(parfem);

                return Result.Ok<ParfemDto>(MapToDto(parfem));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public ParfemDto Get(long id)
        {
            Parfem parfem = _parfemRepository.Get(id);
            if (parfem== null)
            {
                return null;
            }

            return MapToDto(parfem);
        }

        public Result<List<ParfemDto>> GetAll()
        {
            var parfems = _parfemRepository.GetAll().ToList();
            return MapToDto(parfems);
        }

        public Result<ParfemDto> Remove(long id)
        {
            Parfem parfem = _parfemRepository.Get(id);
            if (parfem == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }
            try
            {
                parfem.Delete();
                _parfemRepository.Save();
                return MapToDto(parfem);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }
        
        public Result<ParfemDto> UpdateKolicina(long id, int kol)
        {
            Parfem parfem = _parfemRepository.Get(id);
            if (parfem == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }
            try
            {
                parfem.UpdateKolicina(kol);
                _parfemRepository.Save();
                return MapToDto(parfem);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public Result<ParfemDto> Update(long id, ParfemDto dto)
        {
            Parfem parfem = _parfemRepository.Get(id);
            if (parfem == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }
            try
            {
                parfem.Update(dto.par_naziv,dto.par_opis,dto.par_slika,dto.par_kolicina,dto.par_mililitraza,dto.par_dostupan,dto.par_obrisan,dto.par_fab_id,dto.par_vp_id,dto.par_tp_id,dto.par_kp_id);
                _parfemRepository.Save();
                return MapToDto(parfem);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

    }
}
