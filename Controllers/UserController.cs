using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using soan_backend.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace soan_backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController( IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUserToken")]         
        public async Task<IActionResult> GetUserToken()
        {
            var userHttpContext = HttpContext.User;
            var claimsJwt = userHttpContext.Claims;
            var userId = claimsJwt.FirstOrDefault(a => a.Type == ClaimTypes.Sid).Value;
            var checkUserId = _userService.GetUserToken(Convert.ToInt32(userId));

            if(checkUserId == null)
            {
                return BadRequest("Este usuario no existe");
            }

            return Ok(new
            {
                Id = checkUserId.Result.Id,
                Name = checkUserId.Result.Name,
                Email = checkUserId.Result.Email,
                RoleId = checkUserId.Result.RoleId,
                Role = checkUserId.Result.Role.Name
             });
        }

    }
}
