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
                // Check if combination of skrp_par_id and skrp_krp_id already exists in the database
                var existingStavkaKorpe = _stavkaKorpeRepository
                    .FindByParfemIdAndKorpaId(stavkaKorpeDto.skrp_par_id, stavkaKorpeDto.skrp_krp_id);

                if (existingStavkaKorpe != null)
                {
                    return Result.Fail(FailureCode.Internal).WithError("A StavkaKorpe with the same Parfem ID and Korpa ID already exists.");
                }

                // Fetch the price based on parfem id
                var cena = _stavkaCenovnikaRepository.getByParfemId(stavkaKorpeDto.skrp_par_id);
                stavkaKorpeDto.skrp_cena_pj = cena.sc_cena;

                // Map DTO to domain model
                StavkaKorpe stavkaKorpe = MapToDomain(stavkaKorpeDto);

                // Create the new StavkaKorpe
                stavkaKorpe = _stavkaKorpeRepository.Create(stavkaKorpe);

                // Update the Korpa status
                Korpa korpa = _korpaRepository.Get(stavkaKorpe.skrp_krp_id);
                korpa.KorpaNijePrazna();
                _korpaRepository.Save();

                // Return success with the created StavkaKorpe
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

        public Result<List<StavkaKorpeDto>> RemoveAllByUserId(long userId)
        {
            var korpa = _korpaRepository.GetByUserId(userId);

            var stavkeKorpe = _stavkaKorpeRepository.GetAllByKorpaId(korpa.Id).ToList();
            if (stavkeKorpe.Count <= 0)
            {
                return Result.Fail<List<StavkaKorpeDto>>(FailureCode.NotFound);
            }

            foreach (var stavkaKorpe in stavkeKorpe)
            {
                _stavkaKorpeRepository.Remove(stavkaKorpe);
            }

            korpa.KorpaJePrazna();
            _korpaRepository.Save();

            return Result.Ok<List<StavkaKorpeDto>>(MapToDto(stavkeKorpe).Value);
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
