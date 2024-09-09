using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/stavka-kupovine")]
    public class StavkaKupovineController : BaseApiController
    {
        private readonly IStavkaKupovineService _stavkaKupovineService;

        public StavkaKupovineController(IStavkaKupovineService stavkaKupovineService)
        {
            _stavkaKupovineService = stavkaKupovineService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] StavkaKupovineDto stavkaKupovineDto)
        {
            var result = _stavkaKupovineService.Create(stavkaKupovineDto);
            if (result.IsSuccess)
            {
                return CreateResponse(result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var result = _stavkaKupovineService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _stavkaKupovineService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpGet("kupovina/{id}")]
        public ActionResult GetAllByKupovinaId(long id)
        {
            var result = _stavkaKupovineService.GetAllByKupovinaId(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }


    }
}
