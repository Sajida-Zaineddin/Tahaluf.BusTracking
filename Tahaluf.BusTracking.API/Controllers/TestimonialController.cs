using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.BusTracking.Core.Data;
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
        public List<Testimonial> GetAllBooks()
        {
            return testimonialService.GetAllTestimonials();
            
        }
    }
}
