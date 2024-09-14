using AutoMapper;
using FluentResults;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Core.Services
{
    public class FavoritService : BaseService<FavoritDto, Favorit>, IFavoritService
    {
        protected readonly IFavoritRepository _favoritRepository;

        public FavoritService(IFavoritRepository favoritRepository, IMapper mapper) : base(mapper)
        {
            _favoritRepository = favoritRepository;
        }

        public Result<FavoritDto> Create(FavoritDto favoritDto)
        {
            try
            {


                Favorit favorit = MapToDomain(favoritDto);
                favorit = _favoritRepository.Create(favorit);

                return Result.Ok(MapToDto(favorit));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public Result<List<FavoritDto>> GetAll()
        {
            var favoriti = _favoritRepository.GetAll().ToList();
            return MapToDto(favoriti);
        }


        public Result RemoveFavorite(long parfemId, long userId)
        {
            try
            {
                var favorit = _favoritRepository.FindByParfemIdAndUserId(parfemId, userId);
                if (favorit == null)
                {
                    return Result.Fail(FailureCode.NotFound).WithError("Favorite not found.");
                }

                _favoritRepository.Delete(favorit);
                _favoritRepository.Save();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.Internal).WithError(ex.Message);
            }
        }




    }
}
