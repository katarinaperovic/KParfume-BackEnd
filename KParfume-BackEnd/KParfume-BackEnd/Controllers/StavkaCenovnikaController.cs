using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/stavka-cenovnika")]
    public class StavkaCenovnikaController : BaseApiController
    {
        private readonly IStavkaCenovnikaService _stavkaCenovnikaService;

        public StavkaCenovnikaController(IStavkaCenovnikaService stavkaCenovnikaService)
        {
            _stavkaCenovnikaService = stavkaCenovnikaService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] StavkaCenovnikaDto dto)
        {
            var result = _stavkaCenovnikaService.Create(dto);
            if (result.IsSuccess)
            {
                return CreateResponse(result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var result = _stavkaCenovnikaService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _stavkaCenovnikaService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpGet("getByCenovnikId/{id}")]
        public ActionResult GetAllByCenovnikId(long id)
        {
            var result = _stavkaCenovnikaService.GetAllByCenovnikId(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpDelete]
        public ActionResult Remove(long id)
        {
            var result = _stavkaCenovnikaService.Remove(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }



    }
}
