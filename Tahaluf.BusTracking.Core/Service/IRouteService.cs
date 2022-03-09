using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IRouteService
    {
        List<Route> GETALLROUTE();

        bool CREATEROUTE(Route route);

        bool UPDATEROUTE(Route route);

        string DELETEROUTE(int id);
    }
}
