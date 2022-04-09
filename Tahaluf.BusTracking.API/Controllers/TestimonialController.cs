using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService  testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        public List<TestimoinealDTO> GetAllTestimonial()
        {
            return testimonialService.GetAllTestimonials();
        }

        [HttpPost]
        [Route("CreateTestimonial")]
        public bool CREATETestimonial([FromBody] TestimoinealDTO testimonial)
        {
            return testimonialService.CreateTestimonial(testimonial);
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public string DELETEATestimonial(int id)
        {
            return testimonialService.DeleteTestimonial(id);
        }

        [HttpPut]
        [Route("UpdateTestimonial")]
        public bool UPDATEATestimonial([FromBody] TestimoinealUpdateDTO testimonial)
        {
            return testimonialService.UpdateTestimonial(testimonial);
        }

        [HttpPost]
        [Route("Upload")]
        public Testimonial Upload()
        {
            try
            {
                // Image -----> Request ----> Form
                var file = Request.Form.Files[0];
                // file.FileName
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                // create folder "Images" in Tahaluf.LMS.API
                var fullPath = Path.Combine("C:\\Users\\eqbal\\Documents\\New folder\\BusTrackingAngular\\src\\assets\\images", fileName);
                // FileStream
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                // DataBase
                Testimonial testimonial = new Testimonial();
                testimonial.Imagepath = fileName;
                return testimonial;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetTestimonialStatus")]
        public List<Testimonialstatus> GetTestimonialStatus()
        { 
            return testimonialService.GetTestimonialStatus();
        }
    }
}







