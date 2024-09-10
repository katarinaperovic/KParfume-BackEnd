﻿using AutoMapper;
using FluentResults;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System.Security.Principal;
using static KParfume.Core.Domain.Recenzija;

namespace KParfume.Core.Services
{
    public class RecenzijaService : BaseService<RecenzijaDto, Recenzija>, IRecenzijaService
    {
        protected readonly IRecenzijaRepository _recenzijaRepository;
        protected readonly IKupovinaRepository _kupovinaRepository;


        public RecenzijaService(IRecenzijaRepository recenzijaRepository, IKupovinaRepository kupovinaRepository, IMapper mapper) : base(mapper)
        {
            _recenzijaRepository = recenzijaRepository;
            _kupovinaRepository = kupovinaRepository;
        }

        public Result<RecenzijaDto> Create(RecenzijaDto recenzijaDto)
        {
            try
            {
              /*  var rec = new Recenzija(
                    rDto.rec_ocena,
                    rDto.rec_tekst,
                    (StatusRecenzije)rDto.rec_status,
                    rDto.rec_kor_id,
                    rDto.rec_kup_id
                );
                
                
                Recenzija r = _recenzijaRepository.Create(rec);*/

                Recenzija recenzija = MapToDomain(recenzijaDto);
                recenzija = _recenzijaRepository.Create(recenzija);

                return Result.Ok<RecenzijaDto>(MapToDto(recenzija));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }


        public StatusRecenzije MapToStatus(StatusRecenzijeDto dto)
        {
            switch (dto)
            {
                case StatusRecenzijeDto.obrada:
                    return StatusRecenzije.obrada;
                case StatusRecenzijeDto.odobreno:
                    return StatusRecenzije.odobreno;
                case StatusRecenzijeDto.odbijeno:
                    return StatusRecenzije.odbijeno;
                default:
                    throw new ArgumentException("Invalid StatusRecenzijeDto value");
            }
        }

        public Result<RecenzijaDto> Update(long id, RecenzijaDto dto)
        {
            Recenzija r = _recenzijaRepository.Get(id);
            if (r == null)
            {
                return Result.Fail(FailureCode.NotFound);
            }
            try
            {
                r.Update(dto.rec_ocena, dto.rec_tekst, MapToStatus(dto.rec_status), dto.rec_kor_id, dto.rec_kup_id);
                _recenzijaRepository.Save();
                return MapToDto(r);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }


        public Result<List<RecenzijaDto>> GetRecenzijeByFabrikaId(long fabrikaId)
        {
            // Dobavi sve kupovine i filtriraj po kup_fab_id i sacuvaj samo idjeve
            var kupovine = _kupovinaRepository.GetAll()
                                              .Where(k => k.kup_fab_id == fabrikaId)
                                              .Select(k => k.Id)
                                              .ToList();

            if (!kupovine.Any())
            {
                return new List<RecenzijaDto>(); // Ako nema kupovina, vrati praznu listu
            }

            // Dobavi sve recenzije i filtriraj po rec_kup_id
            var recenzije = _recenzijaRepository.GetAll()
                                                .Where(r => kupovine.Contains(r.rec_kup_id))
                                                .ToList();

           
            return recenzije.Select(r => MapToDto(r)).ToList();
        }





    }
}