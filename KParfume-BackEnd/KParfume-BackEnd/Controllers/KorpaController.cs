using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/korpa")]
    public class KorpaController : BaseApiController
    {
        private readonly IKorpaService _korpaService;

        public KorpaController(IKorpaService korpaService)
        {
            _korpaService = korpaService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] KorpaDto korpaDto)
        {
            var result = _korpaService.Create(korpaDto);
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public ActionResult<KorpaDto> Get(long id)
        {
            var result = _korpaService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<List<KorpaDto>> GetAll()
        {
            var result = _korpaService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(long id)
        {
            var result = _korpaService.Remove(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("prazna/{id}")]
        public ActionResult KorpaPrazna(long id)
        {
            var result = _korpaService.KorpaPrazna(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("nije_prazna/{id}")]
        public ActionResult KorpaNijePrazna(long id)
        {
            var result = _korpaService.KorpaNijePrazna(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }



    }
}
