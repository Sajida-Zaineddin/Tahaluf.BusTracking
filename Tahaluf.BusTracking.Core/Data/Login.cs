using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Login
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Userid { get; set; }

        public virtual User User { get; set; }
    }
}
