using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class RouteDTO
    {
        public decimal Id { get; set; }
        public string Xstart { get; set; }
        public string Ystart { get; set; }
        public string Xcurrent { get; set; }
        public string Ycurrent { get; set; }
        public string Xend { get; set; }
        public string Yend { get; set; }
        public decimal Busnumber { get; set; }
    }
}
