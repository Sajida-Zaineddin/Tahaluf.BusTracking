using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class Attendance
    {
        public decimal id { get; set; }
        public DateTime? dateofattendance { get; set; }
        public decimal? studentid { get; set; }
        public decimal? busid { get; set; }
        public decimal? attendancestatus { get; set; }

        public virtual Attendancestatus AttendancestatusNavigation { get; set; }
        public virtual Bu Bus { get; set; }
        public virtual Student Student { get; set; }
    }
}
