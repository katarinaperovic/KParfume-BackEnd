using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;


namespace KParfume_BackEnd.Controllers
{
    [Route("api/ocena")]
    public class OcenaController : BaseApiController
    {
        private readonly IOcenaService _ocenaService;
        public OcenaController(IOcenaService ocenaService)
        {

            _ocenaService = ocenaService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] OcenaDto ocenaDto)
        {
            var result = _ocenaService.Create(ocenaDto);
            return CreateResponse(result);
        }


        [HttpGet]
        public ActionResult<List<OcenaDto>> GetAll()
        {
            var result = _ocenaService.GetAll();
            return CreateResponse(result);
        }

       

    }
}
