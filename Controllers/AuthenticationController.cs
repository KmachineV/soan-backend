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

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin )
        {
            try
            {
                var userAuth = await _userService.Login(userLogin);
                if (userAuth != null)
                {
                    var token = _userService.GetToken(userAuth);
                    return Ok(token.Result);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }


        }
       
    }
}
