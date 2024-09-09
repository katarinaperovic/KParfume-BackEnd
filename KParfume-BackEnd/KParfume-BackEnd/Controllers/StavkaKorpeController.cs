using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/stavka-korpe")]
    public class StavkaKorpeController : BaseApiController
    {
        private readonly IStavkaKorpeService _stavkaKorpeService;

        public StavkaKorpeController(IStavkaKorpeService stavkaKorpeService)
        {
            _stavkaKorpeService = stavkaKorpeService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] StavkaKorpeDto stavkaKorpeDto)
        {
            var result = _stavkaKorpeService.Create(stavkaKorpeDto);
            if (result.IsSuccess)
            {
                return CreateResponse(result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var result = _stavkaKorpeService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _stavkaKorpeService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpGet("korpa/{id}")]
        public ActionResult GetAllByKorpaId(long id)
        {
            var result = _stavkaKorpeService.GetAllByKorpaId(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(long id)
        {
            var result = _stavkaKorpeService.Remove(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }



        [HttpDelete("user/{id}")]
        public ActionResult RemoveByKorpaId(long id) // POZVATI POSLE SVAKE USPESNE KUPOVINE UGNJEZDENO NA FRONTU KAKO BI ISPRAZNILI KORPU TOG USERA, UMESTO KROZ HEADER MOGU ISTO DA SALJEM USERID OD ULOGOVANOG, IZVUCEM IZ JWTA
        {
            var result = _stavkaKorpeService.RemoveAllByUserId(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("inkrement/{id}")]
        public ActionResult InkrementKolicina(long id)
        {
            var result = _stavkaKorpeService.InkrementKolicina(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("dekrement/{id}")]
        public ActionResult DekrementKolicina(long id)
        {
            var result = _stavkaKorpeService.DekrementKolicina(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

    }
}
