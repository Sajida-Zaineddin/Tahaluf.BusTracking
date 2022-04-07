using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Roundstatus
    {
        public decimal Id { get; set; }
        public string roundStatus { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
