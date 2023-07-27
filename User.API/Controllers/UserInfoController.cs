using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Application.Interface;
using User.Domain.UnitOfWork;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfo _uI;

        public UserInfoController(IUserInfo uI)
        {
            _uI = uI;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
            string UserId = HttpContext.User.FindFirst("userid").Value;
            var User = await _uI.Info(UserId);
            return Ok(User);
        }
    }
}
