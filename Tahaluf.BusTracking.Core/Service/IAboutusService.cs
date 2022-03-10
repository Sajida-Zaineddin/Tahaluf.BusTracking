using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IAboutusService
    {
        List<Aboutu> GetAboutus();

        bool CreateAboutus(Aboutu aboutu);

        bool UpdateAboutus(Aboutu aboutu);

        string DeleteAboutus(int id);
    }
}
