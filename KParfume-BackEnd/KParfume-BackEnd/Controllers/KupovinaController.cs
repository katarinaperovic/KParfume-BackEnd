using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/kupovina")]
    public class KupovinaController : BaseApiController
    {
        private readonly IKupovinaService _kupovinaService;

        public KupovinaController(IKupovinaService kupovinaService)
        {
            _kupovinaService = kupovinaService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] KupovinaDto kupovinaDto)
        {
            var result = _kupovinaService.Create(kupovinaDto);
            if (result.IsSuccess)
            {
                return CreateResponse(result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var result = _kupovinaService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _kupovinaService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpGet("user/{id}")]
        public ActionResult GetAllByUserId(long id)
        {
            var result = _kupovinaService.GetAllByUserId(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

    }
}
