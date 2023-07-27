using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.API.Token;
using User.Application.Interface;
using User.Domain.Entity;
using User.Domain.ViewModels;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUp _signUp;
        private readonly ICreateToken _createToken;
        public SignUpController(ISignUp signUp,ICreateToken createToken)
        {

            this._signUp = signUp;
            this._createToken = createToken;
        }
        [HttpPost]
        public async Task<IActionResult> CreatAsync(UserViewModel userViewModel)
        {
            var result=await _signUp.CreatAsync(userViewModel);
           if(result != null) 
            {
                var token = await _createToken.Token(result);
                return Ok(token);
            }
           else
            {
                var error = new ErrorViewModel
                {
                    Message = "The username is already taken."

                };
                return BadRequest(error);
            }
           
        }
    }
}
