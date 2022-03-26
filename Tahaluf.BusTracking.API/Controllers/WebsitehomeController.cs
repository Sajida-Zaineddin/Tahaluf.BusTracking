using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsitehomeController : ControllerBase
    {
        private readonly IWebsitehomeService websitehomeService;
        public WebsitehomeController(IWebsitehomeService _websitehomeService)
        {
            websitehomeService = _websitehomeService;
        }


        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<Websitehome>), StatusCodes.Status200OK)]
        public List<Websitehome> GetAllwebsitehome()
        {
            return websitehomeService.GetAllwebsitehome();
        }


        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool Createwebsitehome([FromBody] Websitehome websitehome)
        {
            return websitehomeService.Createwebsitehome(websitehome);
        }


        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool Updatewebsitehome([FromBody] Websitehome websitehome)
        {
            return websitehomeService.Updatewebsitehome(websitehome);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool Deletewebsitehome(int id)
        {
            return websitehomeService.Deletewebsitehome(id);
        }

        [HttpPost]
        [Route("UploadImage")]
        public Websitehome UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine("D:\\Training\\Tahaluf Training Center 2021\\Chapters\\Final Project\\BusTrackingAngular\\src\\assets\\images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Websitehome websitehome = new Websitehome();
                websitehome.Imagepath = fileName;
                return websitehome;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
