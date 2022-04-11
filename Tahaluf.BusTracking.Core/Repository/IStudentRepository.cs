using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface IStudentRepository
    {
        List<StudentDto> GetAllStudent();
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int id);
        List<Roundstatus> GETROUNDSTATUS();
        List<getParentName> GETPARENTNAME();
        List<Bu> GETBUSNUMBER();
        List<Student> SEARCHSTUDENT(StudentDto studentdto);
        string UpdateAllStudentsBusStatus();
        bool UPDATESTUDENTBUSSTATUS(string x);
        List<ParentStudentsDTO> GetParentStudents(Login login);
        List<Attendance> GetStudentAttendence(Student student);
        List<GetStudentListByTeacher> GetStudentListByTeacher(string TEACHERNAME);
    }
}
