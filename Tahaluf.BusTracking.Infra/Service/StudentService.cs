using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        public List<StudentDto> GetAllStudent()
        {
            return studentRepository.GetAllStudent();
        }
        public bool CreateStudent(Student student)
        {
            return studentRepository.CreateStudent(student);
        }
        public bool UpdateStudent(Student student)
        {
            return studentRepository.UpdateStudent(student);
        }
        public bool DeleteStudent(int id)
        {
            return studentRepository.DeleteStudent(id);
        }
        public List<Roundstatus> GETROUNDSTATUS()
        {
            return studentRepository.GETROUNDSTATUS();
        }
        public List<getParentName> GETPARENTNAME()
        {
            return studentRepository.GETPARENTNAME();
        }
        public List<Bu> GETBUSNUMBER()
        {
            return studentRepository.GETBUSNUMBER();
        }
        public List<Student> SEARCHSTUDENT(StudentDto studentdto)
        {
            return studentRepository.SEARCHSTUDENT(studentdto);
        }
        public string UpdateAllStudentsBusStatus()
        {
            return studentRepository.UpdateAllStudentsBusStatus();
        }
        public bool UPDATESTUDENTBUSSTATUS(string x)
        {
            return studentRepository.UPDATESTUDENTBUSSTATUS(x);
        }
        public List<ParentStudentsDTO> GetParentStudents(Login login)
        {
            return studentRepository.GetParentStudents(login);
        }
        public List<Attendance> GetStudentAttendence(Student student)
        {
            return studentRepository.GetStudentAttendence(student);
        }

        public List<GetStudentListByTeacher> GetStudentListByTeacher(string TEACHERNAME)
        {
            return studentRepository.GetStudentListByTeacher(TEACHERNAME);
        }
    }
}
