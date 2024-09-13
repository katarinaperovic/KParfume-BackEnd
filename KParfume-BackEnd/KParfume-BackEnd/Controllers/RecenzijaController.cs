using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/recenzija")]
    public class RecenzijaController : BaseApiController
    {
        private readonly IRecenzijaService _recenzijaService;

        public RecenzijaController(IRecenzijaService recenzijaService)
        {
            _recenzijaService = recenzijaService;
        }

        
        [HttpPost]
        public ActionResult Create([FromBody] RecenzijaDto recenzijaDto)
        {
            var result = _recenzijaService.Create(recenzijaDto);
            if (result.IsSuccess)
            {
                return CreateResponse(result);
            }
            return BadRequest(result.Errors);
        }


        [HttpGet("getByFabrikaId/{id}")]
        public ActionResult GetAllByFabrikaId(long id)
        {
            var result = _recenzijaService.GetRecenzijeByFabrikaId(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _recenzijaService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, [FromBody] RecenzijaDto recenzijaDto)
        {
            var result = _recenzijaService.Update(id, recenzijaDto);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

    }
}
