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

        bool CREATEATTENDANCE(Attendance attendance);

        bool UPDATEATTENDANCE(Attendance attendance);

        string DELETEATTENDANCE(int id);
    }
}
