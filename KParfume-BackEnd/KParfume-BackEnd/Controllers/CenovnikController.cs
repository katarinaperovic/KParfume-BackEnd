using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;


namespace KParfume_BackEnd.Controllers
{

    [Route("api/cenovnik")]
    public class CenovnikController : BaseApiController
    {
        private readonly ICenovnikService _cenovnikService;

        public CenovnikController(ICenovnikService cenovnikService)
        {
            _cenovnikService = cenovnikService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CenovnikDto cenovnikDto)
        {
            var result = _cenovnikService.Create(cenovnikDto);
            if (result.IsSuccess)
            {
                return CreateResponse(result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var result = _cenovnikService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("fabrikaId/{id}")]
        public ActionResult GetByFabrikaId(long id)
        {
            var result = _cenovnikService.GetByFabrikaId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _cenovnikService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpDelete]
        public ActionResult Remove(long id)
        {
            var result = _cenovnikService.Remove(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

    }
}
