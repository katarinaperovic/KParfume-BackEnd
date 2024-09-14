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

        // GET: api/favorits/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetFavoritesByUserId(long userId)
        {
            var result = _favoritService.GetFavoritesByUserId(userId);
            if (result.IsFailed)
            {
                return NotFound(result.Errors.FirstOrDefault()?.Message);
            }

            var response = result.Value.Select(f => new
            {
                Favorit = f.Item1, // FavoritDto
                Parfem = f.Item2   // ParfemDto
            });

            return Ok(response);
        }


    }
}
