using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IBusService
    {
        List<Bu> GetAllBus();
        bool CreateBus(Bu bus);
        bool UpdateBus(Bu bus);
        bool DeleteBus(int id);
    }
}
