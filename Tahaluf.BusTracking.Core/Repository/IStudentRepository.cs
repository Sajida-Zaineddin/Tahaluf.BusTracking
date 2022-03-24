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

    }
}
