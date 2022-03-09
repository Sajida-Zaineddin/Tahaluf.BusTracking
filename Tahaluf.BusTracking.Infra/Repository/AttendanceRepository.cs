using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.BusTracking.Core.Common;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;

namespace Tahaluf.BusTracking.Infra.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IDbContext DbContext;
        public AttendanceRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CREATEATTENDANCE(Attendance attendance)
        {
            var p = new DynamicParameters();
            p.Add("DATE_OD_ATTENDANCE", attendance.Attendancestatus, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("STUDENT_ID", attendance.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_ID", attendance.Busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ATTENDANCE_STATUS", attendance.Attendancestatus, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("ATTENDANCE_PACKAGE.CREATEATTENDANCE", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public string DELETEATTENDANCE(int id)
        {
            var p = new DynamicParameters();
            p.Add("ATTENDANCEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ATTENDANCE_PACKAGE.DELETEATTENDANCE", p, commandType: CommandType.StoredProcedure);
            return "Succesfully deleted";
        }

        public List<Attendance> GETALLATTENDANCE()
        {
            IEnumerable<Attendance> result = DbContext.Connection.Query<Attendance>("ATTENDANCE_PACKAGE.GETALLATTENDANCE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UPDATEATTENDANCE(Attendance attendance)
        {
            var p = new DynamicParameters();

            p.Add("ATTENDANCEID", attendance.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("DATE_OD_ATTENDANCE", attendance.Attendancestatus, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("STUDENT_ID", attendance.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_ID", attendance.Busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ATTENDANCE_STATUS", attendance.Attendancestatus, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("ATTENDANCE_PACKAGE.UPDATEATTENDANCE", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
