using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;

using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/komentar")]
    public class KomentarController : BaseApiController
    {
        private readonly IKomentarService _komentarService;

        public KomentarController(IKomentarService komentarService)
        {
            _komentarService = komentarService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] KomentarDto komentarDto)
        {
            var result = _komentarService.Create(komentarDto);
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public ActionResult<KomentarDto> Get(long id)
        {
            var result = _komentarService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("vest/{vestId}")]
        public ActionResult<List<KomentarDto>> GetCommentsByVestId(long vestId)
        {
            var result = _komentarService.GetCommentsByVestId(vestId);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<KomentarDto>> GetAll()
        {
            var result = _komentarService.GetAll();
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(long id)
        {
            var result = _komentarService.Remove(id);
            return CreateResponse(result);
        }
    }
}
