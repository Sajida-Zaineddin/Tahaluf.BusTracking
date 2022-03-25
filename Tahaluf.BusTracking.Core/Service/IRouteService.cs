using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IRouteService
    {
        List<RouteDTO> GETALLROUTE();

        bool CREATEROUTE(RouteDTO route);

        bool UPDATEROUTE(RouteDTO route);

        string DELETEROUTE(int id);
    }
}
