using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public  class BusDTO
    {
        public decimal Id { get; set; }
        public decimal? Busnumber { get; set; }

        public string driverName { get; set; }

        public string teeacherName { get; set; }
    }
}
