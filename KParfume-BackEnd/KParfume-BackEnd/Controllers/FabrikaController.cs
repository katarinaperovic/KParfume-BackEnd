using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/fabrika")]
    public class FabrikaController : BaseApiController
    {
        private readonly IFabrikaService _fabrikaService;

        public FabrikaController( IFabrikaService fabrikaService)
        {
            _fabrikaService = fabrikaService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] FabrikaDto fabrikaDto)
        {
            var result = _fabrikaService.Create(fabrikaDto);
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public ActionResult<FabrikaDto> Get(long id)
        {
            var result = _fabrikaService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<FabrikaDto>> GetAll()
        {
            var result = _fabrikaService.GetAll();
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(long id)
        {
            var result = _fabrikaService.Remove(id);
            return CreateResponse(result);
        }

    }
}
