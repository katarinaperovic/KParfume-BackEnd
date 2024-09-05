using KParfume.API.Controllers;
using KParfume.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    [Route("api/svojstva-parfema")]
    public class SvojstvaParfemaController : BaseApiController
    {
        private readonly ISvojstvaParfemaService _svojstvaParfemaService;

        public SvojstvaParfemaController(ISvojstvaParfemaService svojstvaParfemaService)
        {
            _svojstvaParfemaService = svojstvaParfemaService;
        }

        [HttpGet("vrsta-parfema")]
        public ActionResult GetAllVrstaParfema()
        {
            var result = _svojstvaParfemaService.GetAllVrstaParfema();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("tip-parfema")]
        public ActionResult GetAllTipParfema()
        {
            var result = _svojstvaParfemaService.GetAllTipParfema();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("kategorija-parfema")]
        public ActionResult GetAllKategorijaParfema()
        {
            var result = _svojstvaParfemaService.GetAllKategorijaParfema();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("vrsta-parfema/{id}")]
        public ActionResult GetVrstaParfema(long id)
        {
            var result = _svojstvaParfemaService.GetVrstaParfema(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("tip-parfema/{id}")]
        public ActionResult GetTipParfema(long id)
        {
            var result = _svojstvaParfemaService.GetTipParfema(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("kategorija-parfema/{id}")]
        public ActionResult GetKategorijaParfema(long id)
        {
            var result = _svojstvaParfemaService.GetKategorijaParfema(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

    }
}
