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

       

    }
}
