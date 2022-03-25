using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {

        private readonly ITestimonialRepository  _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {

            _testimonialRepository = testimonialRepository;
        }

        public bool CreateTestimonial(TestimoinealDTO testimonial)
        {
           return _testimonialRepository.CreateTestimonial(testimonial);
        }

        public string DeleteTestimonial(int id)
        {
            return _testimonialRepository.DeleteTestimonial(id);
        }

        public List<TestimoinealDTO> GetAllTestimonials()
        {
            return _testimonialRepository.GetAllTestimonials();
        }

        public bool UpdateTestimonial(TestimoinealUpdateDTO testimonial)
        {
            return _testimonialRepository.UpdateTestimonial(testimonial);
        }

        public List<Testimonialstatus> GetTestimonialStatus() { 
        
            return _testimonialRepository.GetTestimonialStatus();
        }
    }
}
