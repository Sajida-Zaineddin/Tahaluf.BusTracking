using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface IWebsitehomeRepository
    {
        List<Websitehome> GetAllwebsitehome();
        bool Createwebsitehome(Websitehome websitehome);
        bool Updatewebsitehome(Websitehome websitehome);
        bool Deletewebsitehome(int Id);

    }
}
