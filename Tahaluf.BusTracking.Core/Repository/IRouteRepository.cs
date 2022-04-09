using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Repository
{
 public   interface IRouteRepository
    {
        List<Route> GETALLROUTE();
        bool CREATEROUTE(Route route);
        bool UPDATEROUTE(Route route);
        string DELETEROUTE(int id);
        Route SELECTFROMROUTEBYUSERNAME(string email);
        bool SETCURRENTBUSLOCATION(SetCurrentBusLocationDTO setCurrentBusLocationDTO);
        bool setCurrentBusLocationAfterEnd(SetCurrentBusLocationDTO setCurrentBusLocationDTO);
         List<RouteWithNameDTO> GetRouteWithNameDTO();
        List<RouteDTO> getBusRouteDTO();
    }
}
