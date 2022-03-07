using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Website
    {
        public decimal Id { get; set; }
        public string Websitename { get; set; }
        public string Websitelogo { get; set; }
        public decimal? Contactusid { get; set; }
        public decimal? Aboutusid { get; set; }

        public virtual Aboutu Aboutus { get; set; }
        public virtual Contactu Contactus { get; set; }
        public virtual ICollection<Websitefooter> Websitefooters { get; set; }
        public virtual ICollection<Websitehome> Websitehomes { get; set; }
    }
}
