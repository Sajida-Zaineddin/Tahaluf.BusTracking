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
            p.Add("DATE_OF_ATTENDANCE", attendancedto.Dateofattendance, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("STATUS", attendancedto.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("NAME", attendancedto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUSNUMBER", attendancedto.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);


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

        public List<AttendanceDto> GETALLATTENDANCE()
        {
            IEnumerable<AttendanceDto> result = DbContext.Connection.Query<AttendanceDto>("ATTENDANCE_PACKAGE.GETATTENDANCEDTO", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UPDATEATTENDANCE(AttendanceDto attendancedto)
        {
            var p = new DynamicParameters();

            p.Add("ATTENDANCEID", attendancedto.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("DATE_OF_ATTENDANCE", attendancedto.Dateofattendance, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("STATUS", attendancedto.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("NAME", attendancedto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUSNUMBER", attendancedto.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("ATTENDANCE_PACKAGE.UPDATEATTENDANCE", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
