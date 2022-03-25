using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface IAttendanceRepository
    {
        List<AttendanceDto> GETALLATTENDANCE();

        bool CREATEATTENDANCE(AttendanceDto attendancedto);

        bool UPDATEATTENDANCE(AttendanceDto attendancedto);

        string DELETEATTENDANCE(int id);
        List<Bu> GETBUSNUMBER();
        List<Student> GETSTUDENTNAME();
        List<Attendancestatus> GETATTENDANCESTATUS();
    }
}
