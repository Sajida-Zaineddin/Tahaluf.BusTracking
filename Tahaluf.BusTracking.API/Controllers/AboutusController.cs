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
    public class AboutusController : ControllerBase
    {
        private readonly IAboutusService  aboutusService;

        public AboutusController(IAboutusService aboutusService)
        {
            this.aboutusService = aboutusService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Aboutu>), StatusCodes.Status200OK)]
        public List<Aboutu> GetAboutus()
        {
            return aboutusService.GetAboutus();
        }

        [HttpPost]
        [Route("CreateAboutus")]
        public bool CreateAboutus([FromBody] Aboutu  aboutu)
        {
            return aboutusService.CreateAboutus(aboutu);
        }

        [HttpPut]
        [Route("UpdateAboutus")]
        public bool UpdateAboutus([FromBody] Aboutu  aboutu)
        {
            return aboutusService.UpdateAboutus(aboutu);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public string DeleteAboutus(int id)
        {
            return aboutusService.DeleteAboutus(id);
        }

        [HttpPost]
        [Route("Upload")]
        public Aboutu Upload()
        {
            try
            {
                // Image -----> Request ----> Form
                var file = Request.Form.Files[0];
                // file.FileName
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                // create folder "Images" in Tahaluf.LMS.API
                var fullPath = Path.Combine("C:\\Users\\eqbal\\Documents\\GitHub\\BusTrackingAngular\\src\\assets\\images", fileName);
                // FileStream
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                // DataBase
                Aboutu  aboutu   = new Aboutu();
                aboutu.Imagepath = fileName;
                return aboutu;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Aboutu GetById(int id) 
        { 
             return aboutusService.GetById(id);
        }
    }
}
