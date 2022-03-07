using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Aboutu
    {
        
        public decimal Id { get; set; }
        public string Imagepath { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }

        public virtual ICollection<Aboutuseditor> Aboutuseditors { get; set; }
        public virtual ICollection<Website> Websites { get; set; }
    }
}
