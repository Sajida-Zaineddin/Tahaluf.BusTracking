using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface ITestimonialRepository
    {

        List<Testimonial> GetAllTestimonials();

        bool CreateTestimonial(Testimonial testimonial );

        bool UpdateTestimonial(Testimonial  testimonial);

        string DeleteTestimonial(int id);
    }
}
