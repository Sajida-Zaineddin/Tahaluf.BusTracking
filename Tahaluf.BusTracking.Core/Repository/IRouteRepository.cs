using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Repository
{
 public   interface IRouteRepository
    {
        List<RouteDTO> GETALLROUTE();

        bool CREATEROUTE(RouteDTO route);

        bool UPDATEROUTE(RouteDTO route);

        string DELETEROUTE(int id);
    }
}
