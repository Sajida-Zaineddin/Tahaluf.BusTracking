using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
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
        public List<Attendance> GETALLATTENDANCE()
        {
            return attendanceService.GETALLATTENDANCE();
        }


        [HttpPost]
        [Route("Create")]
        public bool CREATEATTENDANCE([FromBody] Attendance attendance)
        {
            return attendanceService.CREATEATTENDANCE(attendance);
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public string DELETEATTENDANCE(int id)
        {
            return attendanceService.DELETEATTENDANCE(id);
        }

        [HttpPut]
        [Route("Update")]
        public bool UPDATEATTENDANCE([FromBody] Attendance attendance)
        {
            return attendanceService.UPDATEATTENDANCE(attendance);
        }
    }
}
