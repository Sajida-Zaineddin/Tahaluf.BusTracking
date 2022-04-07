using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.BusTracking.Core.Common;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
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
        public bool CREATEATTENDANCE(AttendanceDto attendancedto)
        {
            var p = new DynamicParameters();
            p.Add("DATE_OF_ATTENDANCE", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("STUDENTNAME", attendancedto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUS_NUMBER", attendancedto.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ATTENDANCESTATUSs", attendancedto.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("test2020", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public string DELETEATTENDANCE(int id)
        {
            var p = new DynamicParameters();
            p.Add("ATTENDANCEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ATTENDANCE_PACKAGE.DELETEATTENDANCE", p, commandType: CommandType.StoredProcedure);
            return "Succesfully deleted";
        }
        public List<AttendanceDto> GETALLATTENDANCE()
        {
            IEnumerable<AttendanceDto> result = DbContext.Connection.Query<AttendanceDto>("ATTENDANCE_PACKAGE.GETATTENDANCEDTO", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<AttendanceStatus> GETATTENDANCESTATUS()
        {
            IEnumerable<AttendanceStatus> result = DbContext.Connection.Query<AttendanceStatus>("ATTENDANCE_PACKAGE.GETATTENDANCESTATUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Bu> GETBUSNUMBER()
        {
            IEnumerable<Bu> result = DbContext.Connection.Query<Bu>("ATTENDANCE_PACKAGE.GETBUSNUMBER", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GETSTUDENTNAME()
        {
            IEnumerable<Student> result = DbContext.Connection.Query<Student>("ATTENDANCE_PACKAGE.GETSTUDENTNAME", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UPDATEATTENDANCE(AttendanceDto attendancedto)
        {
            var p = new DynamicParameters();
            p.Add("ATTENDANCEID", attendancedto.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("DATE_OF_ATTENDANCE", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("STUDENTNAME", attendancedto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUS_NUMBER", attendancedto.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ATTENDANCESTATUSs", attendancedto.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ATTENDANCE_PACKAGE.UPDATEATTENDANCE", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<GETTEACHERINFONEW> GETTEACHERINFONEW(Login login)
        {
            var p = new DynamicParameters();
            p.Add("usern", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<GETTEACHERINFONEW> result = DbContext.Connection.Query<GETTEACHERINFONEW>("test12", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public studentEmail GETSTUDENTEMAIL(int StudentId)
        {
            var p = new DynamicParameters();
            p.Add("@StudentID", StudentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<studentEmail> result = DbContext.Connection.Query<studentEmail>("ATTENDANCE_PACKAGE.GETSTUDENTEMAIL", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
