using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class GetBusTeachersDTO
    {
        public decimal? Busnumber { get; set; }
        public decimal? Busteacher { get; set; }
        public string FullName { get; set; }

    }
}
