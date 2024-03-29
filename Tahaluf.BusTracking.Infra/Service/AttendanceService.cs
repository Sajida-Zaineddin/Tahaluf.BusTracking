﻿using System;
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
        public List<AttendanceStatus> GETATTENDANCESTATUS()
        {
            return attendanceRepository.GETATTENDANCESTATUS();
        }
        public List<Bu> GETBUSNUMBER()
        {
            return attendanceRepository.GETBUSNUMBER();
        }
        public List<Student> GETSTUDENTNAME()
        {
            return attendanceRepository.GETSTUDENTNAME();
        }
        public bool UPDATEATTENDANCE(AttendanceDto attendancedto)
        {
            return attendanceRepository.UPDATEATTENDANCE(attendancedto);
        }
        public studentEmail GETSTUDENTEMAIL(int StudentId)
        {
            return attendanceRepository.GETSTUDENTEMAIL(StudentId);
        }
        public List<GETTEACHERINFONEW> GETTEACHERINFONEW(Login login)
        {
            return attendanceRepository.GETTEACHERINFONEW(login);
        }

        public List<AttendansByStudentId> StudentAttendeans(Student student) { 
        
            return attendanceRepository.StudentAttendeans(student);
        }
    }
}
