using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
using KParfume.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KParfume_BackEnd.Controllers
{
    //[Authorize(Policy = "clientPolicy")]
    [Route("api/users")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /*
                [HttpGet("GetById/{userId:int}")]
                public ActionResult<UserDto> GetById(long userId)
                {
                    var result = _userService.GetById(userId);
                    return CreateResponse(result);
                }*/

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            var result = _userService.GetAll();
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(long id)
        {
            var result = _userService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetById")]
        public ActionResult<UserDto> GetById()
        {
            var loggedUserId = long.Parse(User.FindFirst("id")?.Value);
            var result = _userService.GetById(loggedUserId);
            return CreateResponse(result);
        }
    }
}
