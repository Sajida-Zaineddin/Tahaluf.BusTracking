using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsitefooterController : ControllerBase
    {
        private readonly IWebsitefooterService websitefooterService;
        public WebsitefooterController(IWebsitefooterService _websitefooterService)
        {
            websitefooterService = _websitefooterService;
        }
        
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<Websitefooter>), StatusCodes.Status200OK)]
        public List<Websitefooter> GetAllwebsitefooter()
        {
            return websitefooterService.GetAllwebsitefooter();
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool Createwebsitefooter([FromBody] Websitefooter websitefooter)
        {
            return websitefooterService.Createwebsitefooter(websitefooter);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool Updatewebsitefooter([FromBody] Websitefooter websitefooter)
        {
            return websitefooterService.Updatewebsitefooter(websitefooter);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool Deletewebsitefooter(int Id)
        {
            return websitefooterService.Deletewebsitefooter(Id);
        }
    }
}
