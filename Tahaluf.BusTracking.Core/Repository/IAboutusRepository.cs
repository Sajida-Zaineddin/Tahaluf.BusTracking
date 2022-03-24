using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface IAboutusRepository
    {

        List<Aboutu> GetAboutus();

        bool CreateAboutus(Aboutu  aboutu);

        bool UpdateAboutus(Aboutu aboutu);

        string DeleteAboutus(int id);

        Aboutu GetById(int id);

    }
}
