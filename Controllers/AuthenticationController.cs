using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using soan_backend.Helpers.UserHelpers;
using soan_backend.Services.Interfaces;

namespace soan_backend.Controllers
{
    [ApiController]
    [Route("api/authetication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordHashing _passwordHashing;

        public AuthenticationController(IUserService userService, IPasswordHashing passwordHashing)
        {
            _userService = userService;
            _passwordHashing = passwordHashing;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin )
        {
            try
            {
                var userAuth = await _userService.Login(userLogin);
                if (userAuth != null)
                {
                    var isValid = _passwordHashing.Check(userAuth.Password_Bash, userLogin.Password_Bash);
                    if (isValid)
                    {
                        var token = _userService.GetToken(userAuth);
                        return Ok(token.Result);
                    }
                    else
                    {
                        return Unauthorized("Email o contraseña incorrectos");
                    }
                  
                }
                return Unauthorized("Email o contraseña incorrectos");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }


        }
       
    }
}
