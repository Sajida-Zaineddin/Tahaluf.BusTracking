using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Role
    {
      
        public decimal Id { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
