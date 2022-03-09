using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IAttendanceService
    {
        List<Attendance> GETALLATTENDANCE();

        bool CREATEATTENDANCE(Attendance attendance);

        bool UPDATEATTENDANCE(Attendance attendance);

        string DELETEATTENDANCE(int id);
    }
}
