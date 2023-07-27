using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.API.Token;
using User.Application.Interface;
using User.Domain.ViewModels;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        private readonly ICreateToken _createToken;
        public LoginController(ILogin login, ICreateToken createToken = null)
        {
            this._login = login;
            this._createToken = createToken;
        }
        [HttpPost]
        public async Task<IActionResult> CreatAsync(LoginViewModel loginViewModel)
        {
            var result = await _login.LoginAsync(loginViewModel);
            if (result!=null)
            {
                var token = await _createToken.Token(result);
                return Ok(token);
            }
            else
            {
                var error = new ErrorViewModel
                {
                    Message = "The username or password is incorrect."

                };
                return BadRequest(error);
            }

        }
    }
}
