using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Contactu
    { 
        public decimal Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Massage { get; set; }

       string s
        public virtual ICollection<Website> Websites { get; set; }
    }
}
