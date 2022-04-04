using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService loginService;

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



        [HttpGet]
        [Route("GetAllUsersWithNames")]
        public List<LoginWithFullNamesDTO> GetAllUsersWithNames()
        {
            return loginService.GetAllUsersWithNames();
        }


        [HttpPost]
        [Route("CreateLoginUser")]
        public bool CreateLoginUser([FromBody] Login login)
        {

            return loginService.CreateLoginUser(login);
        }


        [HttpPut]
        [Route("UpdateLoginUser")]
        public bool UpdateLoginUser([FromBody] Login login) { 
        
            return loginService.UpdateLoginUser(login); 
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public string DeleteLoginUser(int id) { 
        
            return loginService.DeleteLoginUser(id);
        }


        [HttpPut]
        [Route("UpdateLoginUserPassword")]
        public bool UpdateLoginUserPassword([FromBody]Login login)
        {
            return loginService.UpdateLoginUserPassword(login);
        }

    }
}
