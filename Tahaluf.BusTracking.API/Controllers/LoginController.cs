using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService  loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;

        }
        [HttpPost]
        [Route("login")]
        public IActionResult Auth([FromBody] Login login)
        {
            var token = loginService.Auth(login);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }

    }
}
