using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository attendanceRepository;
        public AttendanceService(IAttendanceRepository _attendanceRepository)
        {
            attendanceRepository = _attendanceRepository;

        }
        public bool CREATEATTENDANCE(AttendanceDto attendancedto)
        {
            return attendanceRepository.CREATEATTENDANCE(attendancedto);
        }


        public string DELETEATTENDANCE(int id)
        {
            return attendanceRepository.DELETEATTENDANCE(id);
        }

        public List<AttendanceDto> GETALLATTENDANCE()
        {
            return attendanceRepository.GETALLATTENDANCE();
        }

        public bool UPDATEATTENDANCE(AttendanceDto attendancedto)
        {
            return attendanceRepository.UPDATEATTENDANCE(attendancedto);
        }

  
    }
}
