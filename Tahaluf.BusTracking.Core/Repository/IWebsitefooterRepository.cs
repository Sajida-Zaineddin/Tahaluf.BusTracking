using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface IWebsitefooterRepository
    {
        List<Websitefooter> GetAllwebsitefooter();
        bool Createwebsitefooter(Websitefooter websitefooter);
        bool Updatewebsitefooter(Websitefooter websitefooter);
        bool Deletewebsitefooter(int Id);
    }
}
