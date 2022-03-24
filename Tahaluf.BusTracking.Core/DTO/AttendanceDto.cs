using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
  public  class AttendanceDto
    {
        public decimal Id { get; set; }
        public DateTime Dateofattendance { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public decimal Busnumber { get; set; }
    }
}
