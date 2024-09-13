using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;


namespace KParfume_BackEnd.Controllers
{

    [Route("api/izvestaj")]
    public class IzvestajController : BaseApiController
    {
        private readonly IIzvestajService _izvestajService;

        public IzvestajController(IIzvestajService izvestajService)
        {
            _izvestajService = izvestajService;
        }

        [HttpPost("{fabrikaId}")]
        public IActionResult Create([FromBody] IzvestajDto izvestajDto, long fabrikaId)
        {
            var result = _izvestajService.Create(izvestajDto, fabrikaId);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpGet("manager/{id}")]
        public IActionResult GetAll(long id)
        {
            var result = _izvestajService.GetAllForAuthor(id);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }




    }
}
