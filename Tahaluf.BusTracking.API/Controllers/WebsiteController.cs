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
    public class WebsiteController : ControllerBase
    {
        private readonly IWebsiteService websiteService;
        public WebsiteController(IWebsiteService _websiteService)
        {
            websiteService = _websiteService;
        }



        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<Website>), StatusCodes.Status200OK)]
        public List<Website> GetAllWebsite()
        {
            return websiteService.GetAllWebsite();
        }


        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool CreateWebsite(Website website)
        {
            return websiteService.CreateWebsite(website);
        }


        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool UpdateWebsite([FromBody] Website website)
        {
            return websiteService.UpdateWebsite(website);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool DeleteWebsite([FromBody] int Id)
        {
            return websiteService.DeleteWebsite(Id);
        }

        [HttpPost]
        [Route("UploadImage")]
        public Website UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0]; 
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine("Image", fileName); 
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Website website = new Website();
                website.Websitelogo = fileName;
                return website;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
