using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Student
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string xhome { get; set; }
        public string yhome { get; set; }
        public string grade { get; set; }
        public decimal? roundid { get; set; }
        public decimal? parentid { get; set; }
        public decimal? busid { get; set; }
        public string inbusstatus { get; set; }
        public virtual Bu Bus { get; set; }
        public virtual User Parent { get; set; }
        public virtual Roundstatus Round { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
