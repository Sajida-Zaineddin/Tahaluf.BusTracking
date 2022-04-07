using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Websitehome
    {
        public decimal Id { get; set; }
        public string Imagepath { get; set; }
        public string Titel { get; set; }
        public string Text { get; set; }
        public decimal? Websiteid { get; set; }
        public virtual Website Website { get; set; }
    }
}
