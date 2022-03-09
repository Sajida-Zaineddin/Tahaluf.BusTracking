using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutusEditorController : ControllerBase
    {
        private readonly IAboutusEditorService aboutusEditorService;

        public AboutusEditorController(IAboutusEditorService _aboutusEditorService)
        {
            aboutusEditorService = _aboutusEditorService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Aboutuseditor>), StatusCodes.Status200OK)]
        [Route("GetAll")]
        public List<Aboutuseditor> GETAABOUTUSEDITOR()
        {
            return aboutusEditorService.GETAABOUTUSEDITOR();
        }

        [HttpPost]
        [Route("Create")]
        public bool CREATEABOUTUSEDITOR([FromBody] Aboutuseditor aboutuseditor)
        {
            return aboutusEditorService.CREATEABOUTUSEDITOR(aboutuseditor);
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public string DELETEABOUTUSEDITOR(int id)
        {
            return aboutusEditorService.DELETEABOUTUSEDITOR(id);
        }

        [HttpPut]
        [Route("Update")]
        public bool UPDATEABOUTUSEDITOR([FromBody] Aboutuseditor aboutuseditor)
        {
            return aboutusEditorService.UPDATEABOUTUSEDITOR(aboutuseditor);
        }

        [HttpPost]
        [Route("Upload")]
        public Aboutuseditor Upload()
        {
            try
            {
                // Image -----> Request ----> Form
                var file = Request.Form.Files[0];

                // file.FileName
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // create folder "Images" in Tahaluf.LMS.API
                var fullPath = Path.Combine("Images", fileName);

                // FileStream
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // DataBase
                Aboutuseditor aboutuseditor = new Aboutuseditor();
                aboutuseditor.Imagepath = fileName;
                return aboutuseditor;

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
