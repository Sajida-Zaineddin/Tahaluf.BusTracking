﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
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
        [Route("GetAll")]
        public List<StudentDto> GetAllStudent()
        {
            return _studentService.GetAllStudent();
        }

        [HttpGet]
        [Route("GetRoundStatus")]
        public List<Roundstatus> GETROUNDSTATUS()
        {
            return _studentService.GETROUNDSTATUS();
        }

        [HttpGet]
        [Route("GetParentName")]
        public List<getParentName> GETPARENTNAME()
        {
            return _studentService.GETPARENTNAME();
        }

        [HttpGet]
        [Route("GetBusNum")]
        public List<Bu> GETBUSNUMBER()
        {
            return _studentService.GETBUSNUMBER();
        }

        [HttpPost]
        [Route("Create")]
        public bool CreateStudent([FromBody] Student student)
        {
            return _studentService.CreateStudent(student);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateStudent([FromBody] Student student)
        {
            return _studentService.UpdateStudent(student);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteStudent(int id)
        {
            return _studentService.DeleteStudent(id);
        }

        [HttpPost]
        [Route("SearchStudent")]
        public List<Student> SEARCHSTUDENT([FromBody] StudentDto studentdto)
        {
            return _studentService.SEARCHSTUDENT(studentdto);
        }

        [HttpGet]
        [Route("UpdateAllStudentsBusStatus")]
        public string UpdateAllStudentsBusStatus()
        {
            return _studentService.UpdateAllStudentsBusStatus();
        }

        [HttpGet]
        [Route("UPDATESTUDENTBUSSTATUS/{x}")]
        public bool UPDATESTUDENTBUSSTATUS(string x)
        {
            return _studentService.UPDATESTUDENTBUSSTATUS(x);
        }

        [HttpPost]
        [Route("GetParentStudents")]
        public List<ParentStudentsDTO> GetParentStudents([FromBody] Login login)
        {
            return _studentService.GetParentStudents(login);
        }

        [HttpPost]
        [Route("GetStudentAttendence")]
        public List<Attendance> GetStudentAttendence([FromBody] Student student) 
        { 
            return _studentService.GetStudentAttendence(student);
        }

        [HttpGet]
        [Route("GetStudentListByTeacher/{TEACHERNAME}")]
        public List<GetStudentListByTeacher> GetStudentListByTeacher(string TEACHERNAME)
        {
            return _studentService.GetStudentListByTeacher(TEACHERNAME);
        }
    }
}
