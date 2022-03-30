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
        bool CreateStudent(StudentDto studentdto);
        bool UpdateStudent(StudentDto studentdto);
        bool DeleteStudent(int id);
        List<Roundstatus> GETROUNDSTATUS();
        List<User> GETPARENTNAME();
        List<Bu> GETBUSNUMBER();
        List<Student> SEARCHSTUDENT(StudentDto studentdto);

        string UpdateAllStudentsBusStatus();
        bool UPDATESTUDENTBUSSTATUS(string x);


    }
}
