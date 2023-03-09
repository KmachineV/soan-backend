using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace soan_backend.Controllers
{
    [ApiController]
    [Route("api/authetication")]
    public class AuthenticationController : ControllerBase
    {
        
        [HttpPost("login")]
        public ActionResult Login()
        {
            return Ok();
        }
       
    }
}
