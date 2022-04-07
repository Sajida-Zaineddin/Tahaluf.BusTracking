using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Websitefooter
    {
        public decimal Id { get; set; }
        public string Abouttext { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Websiteid { get; set; }
        public virtual Website Website { get; set; }
    }
}
