using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class LoginWithFullNamesDTO
    {
        public decimal Id { get; set; }

        public string Username { get; set; }

        public string password { get; set; }
        public string FullName { get; set; }

        public decimal? Userid { get; set; }

    }
}
