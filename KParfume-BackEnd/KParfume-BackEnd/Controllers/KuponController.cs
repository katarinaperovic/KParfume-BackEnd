using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;


namespace KParfume_BackEnd.Controllers
{
    [Route("api/kupon")]
    public class KuponController : BaseApiController
    {
        private readonly IKuponService _kuponService;
        public KuponController(IKuponService kuponService)
        {

            _kuponService = kuponService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] KuponDto kuponDto)
        {
            var result = _kuponService.Create(kuponDto);
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public ActionResult<KuponDto> Get(long id)
        {
            var result = _kuponService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<KuponDto>> GetAll()
        {
            var result = _kuponService.GetAll();
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(long id)
        {
            var result = _kuponService.Remove(id);
            return CreateResponse(result);
        }

        [HttpGet("kod-user/{kod}/{userId}")]
        public ActionResult<KuponDto> GetKuponByKodAndUserId(string kod, long userId)
        {
            var result = _kuponService.GetKuponByKodAndUserId(kod, userId);
            if (result == null)
            {
                return NotFound();
            }
            return CreateResponse(result);
        }

        [HttpPut("iskoriscen/{id}")]
        public ActionResult KuponIskoriscen(long id)
        {
            var result = _kuponService.KuponIskoriscen(id);
            return CreateResponse(result);
        }

    }
}
