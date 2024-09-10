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
    public class IzvestajService : BaseService<IzvestajDto, Izvestaj>, IIzvestajService
    {
        protected readonly IIzvestajRepository _izvestajRepository;

        public IzvestajService(IIzvestajRepository izvestajRepository, IMapper mapper) : base(mapper)
        {
            _izvestajRepository = izvestajRepository;
        }


        public Result<List<IzvestajDto>> GetAllForAuthor(long authorId)
        {
            try
            {
                return MapToDto(_izvestajRepository.GetAllForAuthor(authorId));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

    }
}
