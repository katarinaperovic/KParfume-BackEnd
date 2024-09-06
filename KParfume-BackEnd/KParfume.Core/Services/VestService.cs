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
    public class VestService : BaseService<VestDto,Vest>,IVestService
    {
        protected readonly IVestRepository _vestRepository;

        public VestService(IVestRepository vestRepository, IMapper mapper) : base(mapper) 
        {
            _vestRepository = vestRepository;
        }

        public Result<VestDto> Create(VestDto vestDto)
        {
            try
            {
                Vest vest = MapToDomain(vestDto);
                vest = _vestRepository.Create(vest);

                return Result.Ok(MapToDto(vest));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public VestDto Get(long id)
        {
            Vest vest = _vestRepository.Get(id);
            if (vest == null)
            {
                return null;
            }

            return MapToDto(vest);
        }

        public Result<List<VestDto>> GetAll()
        {
            var vests = _vestRepository.GetAll().ToList();
            return MapToDto(vests);
        }

        public Result<VestDto> Remove(long id)
        {
            try
            {
                Vest vest = _vestRepository.Get(id);
                if (vest == null)
                {
                    return Result.Fail(FailureCode.NotFound);
                }

                _vestRepository.Remove(vest);
                return Result.Ok(MapToDto(vest));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public Result<VestDto> UpdateVest(long id, VestDto dto)
        {
            
                Vest vest = _vestRepository.Get(id);
                if (vest == null)
                {
                    return Result.Fail(FailureCode.NotFound);
                }

                try { 
                vest.Update(dto.ves_admin_id,dto.ves_datum,dto.ves_slika,dto.ves_tekst,dto.ves_naslov);
                _vestRepository.Save();
                return MapToDto(vest);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }



    }
}
