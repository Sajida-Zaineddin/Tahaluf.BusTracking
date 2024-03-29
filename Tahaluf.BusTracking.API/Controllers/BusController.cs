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
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<Bu>), StatusCodes.Status200OK)]
        public List<Bu> GetAllBus()
        {
            return _busService.GetAllBus();
        }

        [HttpPost]
        [Route("Create")]
        public bool CreateBus([FromBody] Bu bus)
        {
            return _busService.CreateBus(bus);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateBus([FromBody] Bu bus)
        {
            return _busService.UpdateBus(bus);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteBus(int id)
        {
            return _busService.DeleteBus(id);
        }

        [HttpGet]
        [Route("GetBusDrivers")]
        public List<GetBusDriversDTO> GetBusDrivers()
        {
            return _busService.GetBusDrivers();
        }

        [HttpGet]
        [Route("GetBusTeachers")]
        public List<GetBusTeachersDTO> GetBusTeaachers()
        {
            return _busService.GetBusTeaachers();
        }

        [HttpGet]
        [Route("GetBusInfoByUsername/{name}")]
        public Bu GetBusInfoByUsername(string name)
        {
            return _busService.GetBusInfoByUsername(name);
        }

        [HttpGet]
        [Route("GetBusStudents/{busid}")]
        public List<Student> GetBusStudents(int busid)
        {
            return _busService.GetBusStudents(busid);
        }

        [HttpGet]
        [Route("GetRouteByBus/{busid}")]
        public List<Route> GetRouteByBus(int busid)
        {
            return _busService.GetRouteByBus(busid);
        }

        [HttpGet]
        [Route("GetStudentsInfoByUsername/{name}")]
        public List<Student> GetStudentsInfoByUsername(string name)
        {
            return _busService.GetBusStudents((int)_busService.GetBusInfoByUsername(name).Id);
        }

        [HttpGet]
        [Route("GetRoutesInfoByUsername/{name}")]
        public List<Route> GetRoutesInfoByUsername(string name)
        {
            return _busService.GetRouteByBus((int)_busService.GetBusInfoByUsername(name).Id);
        }

        [HttpGet]
        [Route("GetStudentList/{BUSNUMBER}")]
        public List<GetStudentListByTeacher> GETSTUDENTLIST(int busnumber)
        {
            return _busService.GETSTUDENTLIST(busnumber);
        }
    }
}
