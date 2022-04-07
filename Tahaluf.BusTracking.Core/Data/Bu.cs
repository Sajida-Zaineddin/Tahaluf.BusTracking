using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Bu
    {
        public decimal Id { get; set; }
        public decimal? Busnumber { get; set; }
        public decimal? Busdriver { get; set; }
        public decimal? Busteacher { get; set; }
        public virtual User BusdriverNavigation { get; set; }
        public virtual User BusteacherNavigation { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
