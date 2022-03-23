using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class StudentDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }

        public string Xhome { get; set; }
        public string Yhome { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public decimal Busnumber { get; set; }
        public string ParentName { get; set; }
    }
}
