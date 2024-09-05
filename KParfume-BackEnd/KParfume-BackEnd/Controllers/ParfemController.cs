using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;


namespace KParfume_BackEnd.Controllers
{
    [Route("api/parfem")]
    public class ParfemController : BaseApiController
    {
        private readonly IParfemService _parfemService;

        public ParfemController(IParfemService parfemService)
        {
            _parfemService = parfemService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] ParfemDto parfemDto)
        {
            var result = _parfemService.Create(parfemDto);
            if (result.IsSuccess)
            {
                return CreateResponse(result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var result = _parfemService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _parfemService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, [FromBody] ParfemDto parfemDto)
        {
            var result = _parfemService.Update(id,parfemDto);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("delete/{id}")]
        public ActionResult Remove(long id)
        {
            var result = _parfemService.Remove(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpPut("kolicina/{id}")]
        public ActionResult UpdateKolicina(long id,[FromBody] int kolicina)
        {
            var result = _parfemService.UpdateKolicina(id, kolicina);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }


    }
}
