﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService routeService;
        public RouteController(IRouteService _routeService)
        {
            routeService = _routeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Route>), StatusCodes.Status200OK)]
        [Route("GetAll")]
        public List<Route> GETALLROUTE()
        {
            return routeService.GETALLROUTE();
        }

        [HttpPost]
        [Route("Create")]
        public bool CREATEROUTE([FromBody] Route route)
        {
            return routeService.CREATEROUTE(route);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public string DELETEROUTE(int id)
        {
            return routeService.DELETEROUTE(id);
        }

        [HttpPut]
        [Route("Update")]
        public bool UPDATEROUTE([FromBody] Route route)
        {
            return routeService.UPDATEROUTE(route);
        }

        [HttpGet]
        [Route("SELECTFROMROUTEBYUSERNAME/{email}")]
        public Route SELECTFROMROUTEBYUSERNAME(string email)
        {
            return routeService.SELECTFROMROUTEBYUSERNAME(email);
        }

        [HttpPost]
        [Route("SETCURRENTBUSLOCATION")]
        public bool SETCURRENTBUSLOCATION([FromBody] SetCurrentBusLocationDTO setCurrentBusLocationDTO)
        {
            return routeService.SETCURRENTBUSLOCATION(setCurrentBusLocationDTO);
        }

        [HttpPost]
        [Route("setCurrentBusLocationAfterEnd")]
        public bool setCurrentBusLocationAfterEnd(SetCurrentBusLocationDTO setCurrentBusLocationDTO)
        {
            return routeService.setCurrentBusLocationAfterEnd(setCurrentBusLocationDTO);
        }

        [HttpGet]
        [Route("GetRouteWithNameDTO")]
        public List<RouteWithNameDTO> GetRouteWithNameDTO() {

            return routeService.GetRouteWithNameDTO();
        }


        [HttpGet]
        [Route("getBusRouteDTO")]
        public List<RouteDTO> getBusRouteDTO() { 
        
            return routeService.getBusRouteDTO();   
        }
    }
}
