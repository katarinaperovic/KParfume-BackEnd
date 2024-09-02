using KParfume.API.Controllers;
using KParfume.API.DTOs;
using KParfume.API.Public;
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

        [HttpGet("GetById")]
        public ActionResult<UserDto> GetById()
        {
            var loggedUserId = long.Parse(User.FindFirst("id")?.Value);
            var result = _userService.GetById(loggedUserId);
            return CreateResponse(result);
        }
    }
}
