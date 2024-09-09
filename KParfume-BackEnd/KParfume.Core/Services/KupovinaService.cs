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
    public class KupovinaService : BaseService<KupovinaDto, Kupovina>,IKupovinaService
    {
        protected readonly IKupovinaRepository _kupovinaRepository;

        public KupovinaService(IKupovinaRepository kupovinaRepository, IMapper mapper) : base(mapper) 
        {
            _kupovinaRepository = kupovinaRepository;
        }

        public Result<KupovinaDto> Create(KupovinaDto kupovinaDto)
        {
            try
            {
                Kupovina kupovina = MapToDomain(kupovinaDto);
                kupovina = _kupovinaRepository.Create(kupovina);

                return Result.Ok<KupovinaDto>(MapToDto(kupovina));

            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public KupovinaDto Get(long id)
        {
            Kupovina kupovina = _kupovinaRepository.Get(id);
            if (kupovina == null)
            {
                return null;
            }

            return MapToDto(kupovina);
        }

        public Result<List<KupovinaDto>> GetAll()
        {
            var kupovinas = _kupovinaRepository.GetAll().ToList();
            return MapToDto(kupovinas);
        }

        public Result<List<KupovinaDto>> GetAllByUserId(long id)
        {
            var kupovinas = _kupovinaRepository.GetAllByUserId(id).ToList();
            return MapToDto(kupovinas);
        }


    }
}
