using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Testimonialstatus
    {
     

        public decimal Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
