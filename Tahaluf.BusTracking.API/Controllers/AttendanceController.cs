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
        public List<Attendancestatus> GETATTENDANCESTATUS()
        {
            return attendanceService.GETATTENDANCESTATUS();
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
        [Route("SendEmail")]
        public bool SendEmail(Email email)
        {
            

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("school Mail", email.EmailFrom);
            message.From.Add(from);

            MailboxAddress mailTo = new MailboxAddress("User", "" + email.EmailTo + "");
            message.To.Add(mailTo);

            message.Subject = "Bus Tracking";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h4>Dear Parents</h4>" +
                "we would like to inform you the" +
                "<p style=\"color:Red\">arrival</p>"+
                "of your child" 
               ;
          
            message.Body = bodyBuilder.ToMessageBody();

            using (var clinte = new SmtpClient())//(Simple Mail Transfer Protocol).
            {

                clinte.Connect("smtp.gmail.com", 587, false);
                clinte.Authenticate(email.EmailFrom, email.Password);
                clinte.Send(message);
                clinte.Disconnect(true);
            }
            return true;
        }
    }
}
