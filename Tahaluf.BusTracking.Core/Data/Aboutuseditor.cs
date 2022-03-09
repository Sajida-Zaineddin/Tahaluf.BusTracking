using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Aboutuseditor
    {
        public decimal Id { get; set; }
        public string Imagepath { get; set; }
        public string Titel { get; set; }
        public string Text { get; set; }
        public decimal? Aboutid { get; set; }

        public virtual Aboutu About { get; set; }

        string s 
    }
}
