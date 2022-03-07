using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Student
    {
        
        public decimal Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Xhome { get; set; }
        public string Yhome { get; set; }
        public string Grade { get; set; }
        public decimal? Roundid { get; set; }
        public decimal? Parentid { get; set; }
        public decimal? Busid { get; set; }

        public virtual Bu Bus { get; set; }
        public virtual User Parent { get; set; }
        public virtual Roundstatus Round { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
