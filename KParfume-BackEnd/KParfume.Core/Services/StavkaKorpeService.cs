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
    public class StavkaKorpeService : BaseService<StavkaKorpeDto,StavkaKorpe>,IStavkaKorpeService
    {
        protected readonly IStavkaKorpeRepository _stavkaKorpeRepository;
        protected readonly IKorpaRepository _korpaRepository;
        protected readonly IStavkaCenovnikaRepository _stavkaCenovnikaRepository;

        public StavkaKorpeService(IStavkaKorpeRepository stavkaKorpeRepository,IKorpaRepository korpaRepository,IStavkaCenovnikaRepository stavkaCenovnikaRepository, IMapper mapper) : base(mapper)
        {
            _stavkaKorpeRepository = stavkaKorpeRepository;
            _korpaRepository = korpaRepository;
            _stavkaCenovnikaRepository = stavkaCenovnikaRepository;
        }

        public Result<StavkaKorpeDto> Create(StavkaKorpeDto stavkaKorpeDto)
        {
            try
            {
                var cena = _stavkaCenovnikaRepository.getByParfemId(stavkaKorpeDto.skrp_par_id);
                stavkaKorpeDto.skrp_cena_pj = cena.sc_cena;

                StavkaKorpe stavkaKorpe = MapToDomain(stavkaKorpeDto);
                                
                stavkaKorpe = _stavkaKorpeRepository.Create(stavkaKorpe);

                Korpa korpa = _korpaRepository.Get(stavkaKorpe.skrp_krp_id);
                korpa.KorpaNijePrazna();
                _korpaRepository.Save();
                
                return Result.Ok<StavkaKorpeDto>(MapToDto(stavkaKorpe));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public StavkaKorpeDto Get(long id)
        {
            StavkaKorpe stavkaKorpe = _stavkaKorpeRepository.Get(id);
            if (stavkaKorpe == null)
            {
                return null;
            }

            return MapToDto(stavkaKorpe);
        }

        public Result<List<StavkaKorpeDto>> GetAll()
        {
            var stavkaKorpe = _stavkaKorpeRepository.GetAll().ToList();
            return MapToDto(stavkaKorpe);
        }

        public Result<List<StavkaKorpeDto>> GetAllByKorpaId(long id)
        {
            var stavkaKorpe = _stavkaKorpeRepository.GetAllByKorpaId(id).ToList();
            return MapToDto(stavkaKorpe);
        }

        public Result<StavkaKorpeDto> Remove(long id)
        {
            StavkaKorpe stavkaKorpe = _stavkaKorpeRepository.Get(id);
            Korpa korpa = _korpaRepository.Get(stavkaKorpe.skrp_krp_id);

            if (stavkaKorpe == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }

            var stavke = _stavkaKorpeRepository.GetAllByKorpaId(korpa.Id);
            if (stavke.Count <= 0)
            {
                korpa.KorpaJePrazna();
                _korpaRepository.Save();
            }
            else if (stavke.Count > 0)
            {
                korpa.KorpaNijePrazna();
                _korpaRepository.Save();
            }

            _stavkaKorpeRepository.Remove(stavkaKorpe);
            return Result.Ok<StavkaKorpeDto>(MapToDto(stavkaKorpe));
        }

        public Result<StavkaKorpeDto> InkrementKolicina(long id)
        {
            StavkaKorpe stavkaKorpe = _stavkaKorpeRepository.Get(id);
            Korpa korpa = _korpaRepository.Get(stavkaKorpe.skrp_krp_id);

            if (stavkaKorpe == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }

            var stavke = _stavkaKorpeRepository.GetAllByKorpaId(korpa.Id);
            if (stavke.Count <= 0)
            {
                korpa.KorpaJePrazna();
                _korpaRepository.Save();
            }
            else if (stavke.Count > 0)
            {
                korpa.KorpaNijePrazna();
                _korpaRepository.Save();
            }

            stavkaKorpe.KolicinaInkrement();
            _stavkaKorpeRepository.Save();
            return Result.Ok<StavkaKorpeDto>(MapToDto(stavkaKorpe));
        }

        public Result<StavkaKorpeDto> DekrementKolicina(long id)
        {
            StavkaKorpe stavkaKorpe = _stavkaKorpeRepository.Get(id);
            Korpa korpa = _korpaRepository.Get(stavkaKorpe.skrp_krp_id);

            if (stavkaKorpe == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }

            stavkaKorpe.KolicinaDekrement();
            if(stavkaKorpe.skrp_kolicina <= 0)
            {
                _stavkaKorpeRepository.Remove(stavkaKorpe);
                _stavkaKorpeRepository.Save();
            }

            var stavke = _stavkaKorpeRepository.GetAllByKorpaId(korpa.Id);
            if (stavke.Count <= 0)
            {
                korpa.KorpaJePrazna();
                _korpaRepository.Save();
            }
            else if (stavke.Count > 0)
            {
                korpa.KorpaNijePrazna();
                _korpaRepository.Save();
            }

            return Result.Ok<StavkaKorpeDto>(MapToDto(stavkaKorpe));
        }


    }
}
