using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Route
    {
        public decimal Id { get; set; }
        public string Xcurrent { get; set; }
        public string Ycurrent { get; set; }
        public string Xnext { get; set; }
        public string Ynext { get; set; }
        public string Xend { get; set; }
        public string Yend { get; set; }
        public decimal? Busid { get; set; }

        public virtual Bu Bus { get; set; }
    }
}
