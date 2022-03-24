using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface ITestimonialService
    {
        List<TestimoinealDTO> GetAllTestimonials();

        bool CreateTestimonial(TestimoinealDTO testimonial);

        bool UpdateTestimonial(TestimoinealUpdateDTO testimonial);

        string DeleteTestimonial(int id);

        List<Testimonialstatus> GetTestimonialStatus();
    }
}
