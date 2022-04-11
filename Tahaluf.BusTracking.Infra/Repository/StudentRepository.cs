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
            IEnumerable<StudentDto> result = DbContext.Connection.Query<StudentDto>("GETSTUDENTDTOXXXX", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateStudent(Student student)
        {
            var p = new DynamicParameters();

            p.Add("NAMEe", student.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_HOME", student.xhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_HOME", student.yhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STD_GRADE", student.grade, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROUND_ID", student.roundid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PARENT_ID", student.parentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_ID", student.busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("CREATESTUDENTXXXX", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("STUDENT_ID", student.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAMEe", student.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_HOME", student.xhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_HOME", student.yhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STD_GRADE", student.grade, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROUND_ID", student.roundid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PARENT_ID", student.parentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_ID", student.busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("UPDATESTUDENTxxxx", p, commandType: CommandType.StoredProcedure);
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
            IEnumerable<Roundstatus> result = DbContext.Connection.Query<Roundstatus>("GETROUNDSTATUSxxxx", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<getParentName> GETPARENTNAME()
        {
            IEnumerable<getParentName> result = DbContext.Connection.Query<getParentName>("GETPARENTNAMExxxxx", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Bu> GETBUSNUMBER()
        {
            IEnumerable<Bu> result = DbContext.Connection.Query<Bu>("GETBUSNUMBERxxxxx", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> SEARCHSTUDENT(StudentDto studentdto)
        {
            var p = new DynamicParameters();
            p.Add("SNAME", studentdto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.Query<Student>("STUDENT_PACKAGE.SEARCHSTUDENT", p, commandType: CommandType.StoredProcedure);
            return result.ToList(); ;
        }
        public string UpdateAllStudentsBusStatus()
        {
            DbContext.Connection.ExecuteAsync("UpdateAllStudentsBusStatus", commandType: CommandType.StoredProcedure);
            return "ok";
        }
        public bool UPDATESTUDENTBUSSTATUS(string x)
        {
            var p = new DynamicParameters();
            p.Add("LATHOME", x, dbType: DbType.String, direction: ParameterDirection.Input);
            DbContext.Connection.ExecuteAsync("UPDATESTUDENTBUSSTATUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<ParentStudentsDTO> GetParentStudents(Login login)
        {
            var p = new DynamicParameters();
            p.Add("parentusername", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<ParentStudentsDTO> result = DbContext.Connection.Query<ParentStudentsDTO>("GetParentStudents", p,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Attendance> GetStudentAttendence(Student student)
        {
            var p = new DynamicParameters();
            p.Add("sid", student.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Attendance> result = DbContext.Connection.Query<Attendance>("getStudentAttendens", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<GetStudentListByTeacher> GetStudentListByTeacher(string TEACHERNAME)
        {
            var p = new DynamicParameters();
            p.Add("TEACHERNAME", TEACHERNAME, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<GetStudentListByTeacher> result = DbContext.Connection.Query<GetStudentListByTeacher>("STUDENT_PACKAGE.GetStudentListByTeacher", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
