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
    public class KorpaService : BaseService<KorpaDto,Korpa>,IKorpaService
    {
        protected readonly IKorpaRepository _korpaRepository;

        public KorpaService( IKorpaRepository korpaRepository, IMapper mapper) : base(mapper)
        {
            _korpaRepository = korpaRepository;
        }

        public Result<KorpaDto> Create(KorpaDto korpaDto)
        {
            try
            {
                Korpa korpa = MapToDomain(korpaDto);
                korpa.KorpaJePrazna();
                korpa = _korpaRepository.Create(korpa);

                return Result.Ok<KorpaDto>(MapToDto(korpa));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public KorpaDto Get(long id)
        {
            Korpa korpa = _korpaRepository.Get(id);
            if (korpa == null)
            {
                return null;
            }

            return MapToDto(korpa);
        }

        public Result<List<KorpaDto>> GetAll()
        {
            var korpe = _korpaRepository.GetAll().ToList();
            return MapToDto(korpe);
        }

        public Result<KorpaDto> Remove(long id)
        {
            Korpa korpa = _korpaRepository.Get(id);
            if (korpa == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }

            _korpaRepository.Remove(korpa);
            return Result.Ok(MapToDto(korpa));
        }

        public Result<KorpaDto> KorpaPrazna(long id)
        {
            Korpa korpa = _korpaRepository.Get(id);
            try
            {
                korpa.KorpaJePrazna();
                _korpaRepository.Save();

                return MapToDto(korpa);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }   
        }

        public Result<KorpaDto> KorpaNijePrazna(long id)
        {
            Korpa korpa = _korpaRepository.Get(id);
            try
            {
                korpa.KorpaNijePrazna();
                _korpaRepository.Save();

                return MapToDto(korpa);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }



    }
}
