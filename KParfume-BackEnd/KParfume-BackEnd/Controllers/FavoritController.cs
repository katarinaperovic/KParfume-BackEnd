using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;


namespace KParfume_BackEnd.Controllers
{
    [Route("api/favorit")]
    public class FavoritController : BaseApiController
    {
        private readonly IFavoritService _favoritService;
        public FavoritController(IFavoritService favoritService)
        {

            _favoritService = favoritService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] FavoritDto favoritDto)
        {
            var result = _favoritService.Create(favoritDto);
            return CreateResponse(result);
        }


        [HttpGet]
        public ActionResult<List<FavoritDto>> GetAll()
        {
            var result = _favoritService.GetAll();
            return CreateResponse(result);
        }

        [HttpDelete("{parfemId}/{userId}")]
        public ActionResult RemoveFavorite(long parfemId, long userId)
        {
            var result = _favoritService.RemoveFavorite(parfemId, userId);
            return CreateResponse(result);
        }


    }
}
