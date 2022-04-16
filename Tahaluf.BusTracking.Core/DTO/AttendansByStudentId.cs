using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class AttendansByStudentId
    {
        public string Status { get; set; }

        public DateTime? dateofattendance { get; set; }

        public string Name { get; set; }

        public decimal? Busnumber { get; set; }

        public string roundStatus { get; set; }

    }
}
