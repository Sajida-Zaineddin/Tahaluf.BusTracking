using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Service;


namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService attendanceService;
        public AttendanceController(IAttendanceService _attendanceService)
        {
            attendanceService = _attendanceService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Attendance>), StatusCodes.Status200OK)]
        [Route("GetAll")]
        public List<AttendanceDto> GETALLATTENDANCE()
        {
            return attendanceService.GETALLATTENDANCE();
        }

        [HttpGet]
        [Route("GetAttendance")]
        public List<AttendanceStatus> GETATTENDANCESTATUS()
        {
            return attendanceService.GETATTENDANCESTATUS();
        }

        [HttpPost]
        [Route("GETTEACHERINFONEW")]
        public List<GETTEACHERINFONEW> GETTEACHERINFONEW(Login login)
        {
            return attendanceService.GETTEACHERINFONEW(login);
        }

        [HttpGet]
        [Route("GetStudent")]
        public List<Student> GETSTUDENTNAME()
        {
            return attendanceService.GETSTUDENTNAME();
        }

        [HttpGet]
        [Route("GetBusNum")]
        public List<Bu> GETBUSNUMBER()
        {
            return attendanceService.GETBUSNUMBER();
        }

        [HttpPost]
        [Route("Create")]
        public bool CREATEATTENDANCE([FromBody] AttendanceDto attendancedto)
        {
            return attendanceService.CREATEATTENDANCE(attendancedto);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public string DELETEATTENDANCE(int id)
        {
            return attendanceService.DELETEATTENDANCE(id);
        }

        [HttpPut]
        [Route("Update")]
        public bool UPDATEATTENDANCE([FromBody] AttendanceDto attendancedto)
        {
            return attendanceService.UPDATEATTENDANCE(attendancedto);
        }

        [HttpPost]
        [Route("SendArrivalEmail")]
        public bool SendArrivalEmail(Email email)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("School Mail", "testaseeltahaluf@gmail.com");
            message.From.Add(from);
            MailboxAddress mailTo = new MailboxAddress("User", "" + email.email + "");
            message.To.Add(mailTo);
            message.Subject = "Bus Tracking";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h4>Dear<that The /h4>" + email.FullName +
                "We Would Like To Inform You That The" + "<p style=\"color:Red\">ARRIVAL</p>" + "Of Your Child (" + email.name + ").   " + DateTime.Now;
            message.Body = bodyBuilder.ToMessageBody();
            using (var clinte = new SmtpClient())
            {
                clinte.Connect("smtp.gmail.com", 587, false);
                clinte.Authenticate("testaseeltahaluf@gmail.com", "aseel.test1234");
                clinte.Send(message);
                clinte.Disconnect(true);
            }
            return true;
        }

        [HttpPost]
        [Route("SendAbsentEmail")]
        public bool SendAbsentEmail(Email email)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("School Mail", "testaseeltahaluf@gmail.com");
            message.From.Add(from);
            MailboxAddress mailTo = new MailboxAddress("User", "" + email.email + "");
            message.To.Add(mailTo);
            message.Subject = "Bus Tracking";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h4>Dear</h4>" + email.FullName +
                "We Would Like To Inform You That The" + "<p style=\"color:Red\">ABSENT</p>" + "Of Your Child (" + email.name + ").   " + DateTime.Now;
            message.Body = bodyBuilder.ToMessageBody();
            using (var clinte = new SmtpClient())//(Simple Mail Transfer Protocol).
            {
                clinte.Connect("smtp.gmail.com", 587, false);
                clinte.Authenticate("testaseeltahaluf@gmail.com", "aseel.test1234");
                clinte.Send(message);
                clinte.Disconnect(true);
            }
            return true;
        }

        [HttpPost]
        [Route("GETSTUDENTEMAIL/{StudentId}")]
        public studentEmail GETSTUDENTEMAIL(int StudentId)
        {
            return attendanceService.GETSTUDENTEMAIL(StudentId);
        }

        [HttpPost]
        [Route("StudentAttendeansWithId")]
        public List<AttendansByStudentId> StudentAttendeans(Student student) {

            return attendanceService.StudentAttendeans(student);
        }
    }
}
