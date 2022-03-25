using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class LoginManageDTO
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rolename { get; set; }
    }
}
