using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
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
        public List<Student> GetAllStudent() 
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
    }
}
