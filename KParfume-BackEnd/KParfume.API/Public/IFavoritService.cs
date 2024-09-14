using FluentResults;
using KParfume.API.DTOs;

namespace KParfume.API.Public
{
    public interface IFavoritService
    {
        Result<FavoritDto> Create(FavoritDto favoritDto);
        Result RemoveFavorite(long parfemId, long userId);
        Result<List<FavoritDto>> GetAll();
        Result<List<(FavoritDto, ParfemDto)>> GetFavoritesByUserId(long userId);

    }
}
