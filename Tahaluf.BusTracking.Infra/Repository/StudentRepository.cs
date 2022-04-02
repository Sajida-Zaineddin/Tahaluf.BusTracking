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
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContext DbContext;
        public StudentRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public List<StudentDto> GetAllStudent()
        {
            IEnumerable<StudentDto> result = DbContext.Connection.Query<StudentDto>("STUDENT_PACKAGE.GETSTUDENTDTO", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateStudent(StudentDto studentdto)
        {
            var p = new DynamicParameters();

            p.Add("NAMEe", studentdto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_HOME", studentdto.Xhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_HOME", studentdto.Yhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STD_GRADE", studentdto.Grade, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROUNDSTATUS", studentdto.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PARENTNAME", studentdto.fullName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUS_NUMBER", studentdto.busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.CREATESTUDENT", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateStudent(StudentDto studentdto)
        {
            var p = new DynamicParameters();
            p.Add("STUDENT_ID", studentdto.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAMEe", studentdto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_HOME", studentdto.Xhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_HOME", studentdto.Yhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STD_GRADE", studentdto.Grade, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROUNDSTATUS", studentdto.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PARENTNAME", studentdto.fullName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUS_NUMBER", studentdto.busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
     

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

        public List<Roundstatus> GETROUNDSTATUS()
        {
            IEnumerable<Roundstatus> result = DbContext.Connection.Query<Roundstatus>("STUDENT_PACKAGE.GETROUNDSTATUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<User> GETPARENTNAME()
        {
            IEnumerable<User> result = DbContext.Connection.Query<User>("STUDENT_PACKAGE.GETPARENTNAME", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Bu> GETBUSNUMBER()
        {
            IEnumerable<Bu> result = DbContext.Connection.Query<Bu>("STUDENT_PACKAGE.GETBUSNUMBER", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> SEARCHSTUDENT(StudentDto studentdto)
        {
            var p = new DynamicParameters();
            p.Add("SNAME", studentdto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.Query<Student>("STUDENT_PACKAGE.SEARCHSTUDENT", p, commandType: CommandType.StoredProcedure);
            return result.ToList(); ;

        }

        public string UpdateAllStudentsBusStatus() {

            DbContext.Connection.ExecuteAsync("UpdateAllStudentsBusStatus", commandType: CommandType.StoredProcedure);
            
            return "ok";
        }

        public bool UPDATESTUDENTBUSSTATUS(string x)
        {
            var p = new DynamicParameters();
            p.Add("LATHOME", x, dbType: DbType.String, direction: ParameterDirection.Input);
            DbContext.Connection.ExecuteAsync("UPDATESTUDENTBUSSTATUS", p,commandType: CommandType.StoredProcedure);

            return true;
        }



        public List<ParentStudentsDTO> GetParentStudents(Login login) {
            var p = new DynamicParameters();
            p.Add("parentusername", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<ParentStudentsDTO> result = DbContext.Connection.Query<ParentStudentsDTO>("GetParentStudents", p,commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<Attendance> GetStudentAttendence(Student student) {
            var p = new DynamicParameters();
            p.Add("sid", student.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Attendance> result = DbContext.Connection.Query<Attendance>("getStudentAttendens", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

    }
}
