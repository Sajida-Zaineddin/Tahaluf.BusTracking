using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetAllStudent")]
        // anyone with token or [Authorize(Role = "Teacher, Student")] [Authorize] 
        //[ProducesResponseType(typeof(List<Student>), StatusCodes.Status200OK)]
        //[Route("api/[controller]")]
        public List<Student> GetAllStudent()
        {
            return _studentService.GetAllStudent();
        }

        [HttpPost]
        [Route("CreateStudent")]
        public bool CreateStudent([FromBody] Student student)
        {
            return _studentService.CreateStudent(student);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public bool UpdateStudent([FromBody] Student student)
        {
            return _studentService.UpdateStudent(student);
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent(int id)
        {
            return _studentService.DeleteStudent(id);
        }
    }
}
