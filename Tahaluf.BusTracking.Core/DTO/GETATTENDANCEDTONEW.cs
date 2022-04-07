using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class GETATTENDANCEDTONEW
    {
        public DateTime Dateofattendance { get; set; }
        public string Name { get; set; }
        public decimal Busnumber { get; set; }
    }
}