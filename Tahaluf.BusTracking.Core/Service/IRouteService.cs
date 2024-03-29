﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IRouteService
    {
        List<Route> GETALLROUTE();
        bool CREATEROUTE(Route route);
        bool UPDATEROUTE(Route route);
        string DELETEROUTE(int id);
        Route SELECTFROMROUTEBYUSERNAME(string email);
        bool SETCURRENTBUSLOCATION(SetCurrentBusLocationDTO setCurrentBusLocationDTO);
        bool setCurrentBusLocationAfterEnd(SetCurrentBusLocationDTO setCurrentBusLocationDTO);
        public List<RouteWithNameDTO> GetRouteWithNameDTO();
        List<RouteDTO> getBusRouteDTO();
    }
}
