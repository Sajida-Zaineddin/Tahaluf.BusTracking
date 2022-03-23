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
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContext DbContext;
        public StudentRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public List<Student> GetAllStudent()
        {
            IEnumerable<Student> result = DbContext.Connection.Query<Student>("STUDENT_PACKAGE.GETALLSTUDENTS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("NAME", student.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_HOME", student.Xhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_HOME", student.Yhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STD_GRADE", student.Grade, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROUND_ID", student.Roundid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PARENT_ID", student.Parentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_ID", student.Busid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.CREATESTUDENT", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("STUDENT_ID", student.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAME", student.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_HOME", student.Xhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_HOME", student.Yhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STD_GRADE", student.Grade, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROUND_ID", student.Roundid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PARENT_ID", student.Parentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_ID", student.Busid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.UPDATESTUDENT", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("STUDENT_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.DELETESTUDENT", p, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
