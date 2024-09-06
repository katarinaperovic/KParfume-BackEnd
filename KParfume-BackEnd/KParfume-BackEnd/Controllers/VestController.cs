using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;


namespace KParfume_BackEnd.Controllers
{
    [Route("api/vest")]
    public class VestController : BaseApiController
    {
        private readonly IVestService _vestService;
        public VestController(IVestService vestService)
        {

            _vestService = vestService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] VestDto vestDto)
        {
            var result = _vestService.Create(vestDto);
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public ActionResult<VestDto> Get(long id)
        {
            var result = _vestService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<VestDto>> GetAll()
        {
            var result = _vestService.GetAll();
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(long id)
        {
            var result = _vestService.Remove(id);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult UpdateVest(long id, [FromBody] VestDto dto)
        {
            var result = _vestService.UpdateVest(id, dto);
            return CreateResponse(result);
        }

    }
}
